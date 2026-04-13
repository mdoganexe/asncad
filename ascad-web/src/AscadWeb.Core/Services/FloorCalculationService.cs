using AscadWeb.Core.Entities;
using AscadWeb.Core.Interfaces;

namespace AscadWeb.Core.Services;

public class FloorCalculationService : IFloorCalculationService
{
    public List<FloorInfo> CalculateArchitecturalLevels(List<FloorInfo> floors)
    {
        if (floors == null || floors.Count == 0)
            return floors ?? new List<FloorInfo>();

        var sorted = floors.OrderBy(f => f.KatNo).ToList();

        // Find ground floor (KatNo == 0) index
        int groundIndex = sorted.FindIndex(f => f.KatNo == 0);
        if (groundIndex < 0)
        {
            // If no ground floor, treat the lowest floor as reference
            groundIndex = 0;
            sorted[0].MimariKot = "0.00";
        }
        else
        {
            sorted[groundIndex].MimariKot = "0.00";
        }

        // Calculate floors above ground (accumulate upward)
        double currentLevel = 0;
        for (int i = groundIndex + 1; i < sorted.Count; i++)
        {
            currentLevel += sorted[i].KatYuksekligi;
            sorted[i].MimariKot = FormatKot(currentLevel);
        }

        // Calculate floors below ground (accumulate downward, negative)
        currentLevel = 0;
        for (int i = groundIndex - 1; i >= 0; i--)
        {
            currentLevel -= sorted[i].KatYuksekligi > 0 ? sorted[i].KatYuksekligi : sorted[i + 1].KatYuksekligi;
            sorted[i].MimariKot = FormatKot(currentLevel);
        }

        return sorted;
    }

    public int CalculateTravelDistance(List<FloorInfo> floors)
    {
        if (floors == null || floors.Count < 2)
            return 0;

        var sorted = floors.OrderBy(f => f.KatNo).ToList();
        double firstLevel = ParseKot(sorted.First().MimariKot);
        double lastLevel = ParseKot(sorted.Last().MimariKot);

        return (int)(lastLevel - firstLevel);
    }

    public int CalculatePitDepth(List<FloorInfo> floors, int beyanYuk)
    {
        if (floors == null || floors.Count == 0)
            return 0;

        var sorted = floors.OrderBy(f => f.KatNo).ToList();
        double firstLevel = ParseKot(sorted.First().MimariKot);

        // EN81-1 minimum pit depth
        int minPitDepth = beyanYuk <= 600 ? 1200 : 1500;

        // Pit depth = absolute value of first floor level + EN81-1 minimum
        int pitFromLevel = (int)Math.Abs(firstLevel);
        return Math.Max(pitFromLevel, minPitDepth);
    }

    public int CalculateOverheadClearance(List<FloorInfo> floors, int machineRoomHeight)
    {
        if (floors == null || floors.Count == 0)
            return 0;

        var sorted = floors.OrderBy(f => f.KatNo).ToList();
        double lastLevel = ParseKot(sorted.Last().MimariKot);

        // Overhead = last floor level + machine room height, minimum 3600mm
        int overhead = (int)lastLevel + machineRoomHeight;
        return Math.Max(overhead, 3600);
    }

    private static string FormatKot(double value)
    {
        return (value / 1000.0).ToString("F2");
    }

    private static double ParseKot(string kot)
    {
        if (string.IsNullOrWhiteSpace(kot))
            return 0;

        if (double.TryParse(kot, System.Globalization.NumberStyles.Float,
            System.Globalization.CultureInfo.InvariantCulture, out double meters))
        {
            return meters * 1000; // Convert from meters to mm
        }

        return 0;
    }
}
