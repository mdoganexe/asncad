using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;
using AscadWeb.Core.Entities;
using AscadWeb.Core.Enums;
using AscadWeb.Core.Interfaces;

namespace AscadWeb.Core.Services;

public class DrawingGeneratorService : IDrawingGeneratorService
{
    private const int ViewBoxWidth = 600;
    private const int ViewBoxHeight = 600;
    private const int Margin = 60;
    private const int DimOffset = 30;
    private const string StrokeColor = "#333";
    private const string DimColor = "#0066cc";
    private const string DoorColor = "#cc6600";
    private const string CwColor = "#888";
    private const string RailColor = "#c00";

    public string GenerateShaftCrossSection(Lift lift)
    {
        var sb = new StringBuilder();
        var drawW = ViewBoxWidth - 2 * Margin;
        var drawH = ViewBoxHeight - 2 * Margin;

        var shaftW = lift.KuyuGenisligi;
        var shaftD = lift.KuyuDerinligi;
        if (shaftW <= 0) shaftW = 2000;
        if (shaftD <= 0) shaftD = 2500;

        var scaleX = (double)drawW / shaftW;
        var scaleY = (double)drawH / shaftD;
        var scale = Math.Min(scaleX, scaleY);

        var sw = shaftW * scale;
        var sh = shaftD * scale;
        var ox = Margin + (drawW - sw) / 2;
        var oy = Margin + (drawH - sh) / 2;

        sb.AppendLine($"<svg xmlns=\"http://www.w3.org/2000/svg\" viewBox=\"0 0 {ViewBoxWidth} {ViewBoxHeight}\" width=\"{ViewBoxWidth}\" height=\"{ViewBoxHeight}\">");
        sb.AppendLine("<style>text{font-family:Arial,sans-serif;font-size:11px;}</style>");

        // Shaft walls
        sb.AppendLine($"<rect x=\"{F(ox)}\" y=\"{F(oy)}\" width=\"{F(sw)}\" height=\"{F(sh)}\" fill=\"none\" stroke=\"{StrokeColor}\" stroke-width=\"2\"/>");

        // Cabin outline
        var cabW = lift.KabinGenisligi > 0 ? lift.KabinGenisligi : (int)(shaftW * 0.6);
        var cabD = lift.KabinDerinligi > 0 ? lift.KabinDerinligi : (int)(shaftD * 0.55);
        var cabSw = cabW * scale;
        var cabSh = cabD * scale;
        var cabX = ox + (sw - cabSw) / 2;
        var cabY = oy + sh - cabSh - 20 * scale;
        sb.AppendLine($"<rect x=\"{F(cabX)}\" y=\"{F(cabY)}\" width=\"{F(cabSw)}\" height=\"{F(cabSh)}\" fill=\"#f0f0f0\" stroke=\"{StrokeColor}\" stroke-width=\"1.5\"/>");

        // Door opening
        var doorW = lift.KapiGenisligi > 0 ? lift.KapiGenisligi : 900;
        var doorSw = doorW * scale;
        var doorX = cabX + (cabSw - doorSw) / 2;
        var doorY = cabY + cabSh - 2;
        sb.AppendLine($"<rect x=\"{F(doorX)}\" y=\"{F(doorY)}\" width=\"{F(doorSw)}\" height=\"6\" fill=\"{DoorColor}\" stroke=\"{DoorColor}\" stroke-width=\"1\"/>");

        // Rail positions (lines)
        var railInset = 15 * scale;
        // Left cabin rail
        sb.AppendLine($"<line x1=\"{F(cabX - railInset)}\" y1=\"{F(cabY)}\" x2=\"{F(cabX - railInset)}\" y2=\"{F(cabY + cabSh)}\" stroke=\"{RailColor}\" stroke-width=\"2\"/>");
        // Right cabin rail
        sb.AppendLine($"<line x1=\"{F(cabX + cabSw + railInset)}\" y1=\"{F(cabY)}\" x2=\"{F(cabX + cabSw + railInset)}\" y2=\"{F(cabY + cabSh)}\" stroke=\"{RailColor}\" stroke-width=\"2\"/>");

        // Counterweight position based on yonKodu
        double cwX, cwY;
        double cwW = 30 * scale, cwH = 20 * scale;
        switch (lift.YonKodu)
        {
            case YonKodu.SOL:
                cwX = ox + 10 * scale;
                cwY = oy + 10 * scale;
                break;
            case YonKodu.SAG:
                cwX = ox + sw - 10 * scale - cwW;
                cwY = oy + 10 * scale;
                break;
            default: // ARKA
                cwX = ox + (sw - cwW) / 2;
                cwY = oy + 10 * scale;
                break;
        }
        sb.AppendLine($"<rect x=\"{F(cwX)}\" y=\"{F(cwY)}\" width=\"{F(cwW)}\" height=\"{F(cwH)}\" fill=\"{CwColor}\" stroke=\"{StrokeColor}\" stroke-width=\"1\"/>");
        sb.AppendLine($"<text x=\"{F(cwX + cwW / 2)}\" y=\"{F(cwY + cwH + 12)}\" text-anchor=\"middle\" fill=\"{CwColor}\" font-size=\"9\">CW</text>");

        // Dimension annotations
        // Width dimension (bottom)
        var dimY = oy + sh + DimOffset;
        sb.AppendLine($"<line x1=\"{F(ox)}\" y1=\"{F(dimY)}\" x2=\"{F(ox + sw)}\" y2=\"{F(dimY)}\" stroke=\"{DimColor}\" stroke-width=\"0.8\"/>");
        sb.AppendLine($"<text x=\"{F(ox + sw / 2)}\" y=\"{F(dimY + 15)}\" text-anchor=\"middle\" fill=\"{DimColor}\">{shaftW} mm</text>");

        // Depth dimension (right)
        var dimX = ox + sw + DimOffset;
        sb.AppendLine($"<line x1=\"{F(dimX)}\" y1=\"{F(oy)}\" x2=\"{F(dimX)}\" y2=\"{F(oy + sh)}\" stroke=\"{DimColor}\" stroke-width=\"0.8\"/>");
        sb.AppendLine($"<text x=\"{F(dimX + 5)}\" y=\"{F(oy + sh / 2)}\" fill=\"{DimColor}\" transform=\"rotate(90,{F(dimX + 5)},{F(oy + sh / 2)})\" text-anchor=\"middle\">{shaftD} mm</text>");

        sb.AppendLine("</svg>");
        return sb.ToString();
    }

    public string GenerateLongitudinalSection(Lift lift)
    {
        var sb = new StringBuilder();
        var floors = lift.Floors?.OrderBy(f => f.KatNo).ToList() ?? new List<FloorInfo>();

        var shaftW = lift.KuyuGenisligi > 0 ? lift.KuyuGenisligi : 2000;
        var pitDepth = lift.KuyuDibi > 0 ? lift.KuyuDibi : 1200;
        var overhead = lift.KuyuKafa > 0 ? lift.KuyuKafa : 3500;

        // Calculate total height
        var totalFloorHeight = floors.Sum(f => f.KatYuksekligi > 0 ? f.KatYuksekligi : 3000);
        if (totalFloorHeight <= 0) totalFloorHeight = 9000;
        var totalHeight = pitDepth + totalFloorHeight + overhead;

        var drawW = ViewBoxWidth - 2 * Margin;
        var drawH = ViewBoxHeight - 2 * Margin;
        var scaleY = (double)drawH / totalHeight;
        var shaftDrawW = Math.Min(drawW * 0.4, shaftW * scaleY);

        var ox = Margin + (drawW - shaftDrawW) / 2;
        var oy = Margin;
        var shaftH = totalHeight * scaleY;

        sb.AppendLine($"<svg xmlns=\"http://www.w3.org/2000/svg\" viewBox=\"0 0 {ViewBoxWidth} {ViewBoxHeight}\" width=\"{ViewBoxWidth}\" height=\"{ViewBoxHeight}\">");
        sb.AppendLine("<style>text{font-family:Arial,sans-serif;font-size:10px;}</style>");

        // Shaft outline
        sb.AppendLine($"<rect x=\"{F(ox)}\" y=\"{F(oy)}\" width=\"{F(shaftDrawW)}\" height=\"{F(shaftH)}\" fill=\"none\" stroke=\"{StrokeColor}\" stroke-width=\"2\"/>");

        // Pit depth at bottom
        var pitH = pitDepth * scaleY;
        var pitY = oy + shaftH - pitH;
        sb.AppendLine($"<line x1=\"{F(ox)}\" y1=\"{F(pitY)}\" x2=\"{F(ox + shaftDrawW)}\" y2=\"{F(pitY)}\" stroke=\"{StrokeColor}\" stroke-width=\"1\" stroke-dasharray=\"4,2\"/>");
        sb.AppendLine($"<text x=\"{F(ox - 5)}\" y=\"{F(pitY + pitH / 2)}\" text-anchor=\"end\" fill=\"{DimColor}\" font-size=\"9\">Kuyu Dibi: {pitDepth} mm</text>");

        // Floor levels
        var currentY = pitY;
        foreach (var floor in floors)
        {
            var floorH = (floor.KatYuksekligi > 0 ? floor.KatYuksekligi : 3000) * scaleY;
            currentY -= floorH;
            if (currentY < oy) currentY = oy;

            sb.AppendLine($"<line x1=\"{F(ox)}\" y1=\"{F(currentY)}\" x2=\"{F(ox + shaftDrawW)}\" y2=\"{F(currentY)}\" stroke=\"{StrokeColor}\" stroke-width=\"1\"/>");
            var label = string.IsNullOrEmpty(floor.MimariKot) ? $"Kat {floor.KatNo}" : $"Kat {floor.KatNo} ({floor.MimariKot})";
            sb.AppendLine($"<text x=\"{F(ox + shaftDrawW + 8)}\" y=\"{F(currentY + 4)}\" fill=\"{StrokeColor}\" font-size=\"9\">{label}</text>");
        }

        // Travel distance annotation
        if (floors.Count >= 2)
        {
            int.TryParse(lift.SeyirMesafesi, out var travel);
            if (travel <= 0) travel = totalFloorHeight;
            sb.AppendLine($"<text x=\"{F(ox + shaftDrawW + 8)}\" y=\"{F(oy + shaftH / 2)}\" fill=\"{DimColor}\" font-size=\"9\">Seyir: {travel} mm</text>");
        }

        // Overhead clearance
        sb.AppendLine($"<text x=\"{F(ox - 5)}\" y=\"{F(oy + 12)}\" text-anchor=\"end\" fill=\"{DimColor}\" font-size=\"9\">Kafa: {overhead} mm</text>");

        // Machine room height label
        sb.AppendLine($"<text x=\"{F(ox + shaftDrawW / 2)}\" y=\"{F(oy - 8)}\" text-anchor=\"middle\" fill=\"{StrokeColor}\" font-size=\"10\">Makine Dairesi</text>");

        sb.AppendLine("</svg>");
        return sb.ToString();
    }

    public string GenerateMachineRoomLayout(Lift lift)
    {
        var sb = new StringBuilder();
        var roomW = lift.KuyuGenisligi > 0 ? lift.KuyuGenisligi : 2000;
        var roomD = lift.KuyuDerinligi > 0 ? lift.KuyuDerinligi : 2500;

        var drawW = ViewBoxWidth - 2 * Margin;
        var drawH = ViewBoxHeight - 2 * Margin;
        var scale = Math.Min((double)drawW / roomW, (double)drawH / roomD);
        var rw = roomW * scale;
        var rh = roomD * scale;
        var ox = Margin + (drawW - rw) / 2;
        var oy = Margin + (drawH - rh) / 2;

        sb.AppendLine($"<svg xmlns=\"http://www.w3.org/2000/svg\" viewBox=\"0 0 {ViewBoxWidth} {ViewBoxHeight}\" width=\"{ViewBoxWidth}\" height=\"{ViewBoxHeight}\">");
        sb.AppendLine("<style>text{font-family:Arial,sans-serif;font-size:10px;}</style>");

        // Room rectangle
        sb.AppendLine($"<rect x=\"{F(ox)}\" y=\"{F(oy)}\" width=\"{F(rw)}\" height=\"{F(rh)}\" fill=\"#fafafa\" stroke=\"{StrokeColor}\" stroke-width=\"2\"/>");

        // Traction machine (circle, center of room)
        var machR = Math.Min(rw, rh) * 0.12;
        var machX = ox + rw * 0.5;
        var machY = oy + rh * 0.45;
        sb.AppendLine($"<circle cx=\"{F(machX)}\" cy=\"{F(machY)}\" r=\"{F(machR)}\" fill=\"#ddd\" stroke=\"{StrokeColor}\" stroke-width=\"1.5\"/>");
        sb.AppendLine($"<text x=\"{F(machX)}\" y=\"{F(machY + 4)}\" text-anchor=\"middle\" fill=\"{StrokeColor}\" font-size=\"9\">Motor</text>");

        // Deflection sheave (smaller circle)
        var sheaveR = machR * 0.6;
        var sheaveX = ox + rw * 0.3;
        var sheaveY = oy + rh * 0.45;
        sb.AppendLine($"<circle cx=\"{F(sheaveX)}\" cy=\"{F(sheaveY)}\" r=\"{F(sheaveR)}\" fill=\"#eee\" stroke=\"{StrokeColor}\" stroke-width=\"1\"/>");
        sb.AppendLine($"<text x=\"{F(sheaveX)}\" y=\"{F(sheaveY + sheaveR + 12)}\" text-anchor=\"middle\" fill=\"{StrokeColor}\" font-size=\"8\">Sapma</text>");

        // Control panel (rect on wall)
        var panelW = rw * 0.2;
        var panelH = rh * 0.08;
        sb.AppendLine($"<rect x=\"{F(ox + rw - panelW - 10)}\" y=\"{F(oy + 10)}\" width=\"{F(panelW)}\" height=\"{F(panelH)}\" fill=\"#cce5ff\" stroke=\"{StrokeColor}\" stroke-width=\"1\"/>");
        sb.AppendLine($"<text x=\"{F(ox + rw - panelW / 2 - 10)}\" y=\"{F(oy + 10 + panelH + 12)}\" text-anchor=\"middle\" fill=\"{StrokeColor}\" font-size=\"8\">Pano</text>");

        // Access door (rect on bottom wall)
        var doorW = rw * 0.15;
        var doorH = 6.0;
        sb.AppendLine($"<rect x=\"{F(ox + 20)}\" y=\"{F(oy + rh - doorH)}\" width=\"{F(doorW)}\" height=\"{F(doorH)}\" fill=\"{DoorColor}\" stroke=\"{DoorColor}\" stroke-width=\"1\"/>");
        sb.AppendLine($"<text x=\"{F(ox + 20 + doorW / 2)}\" y=\"{F(oy + rh - 10)}\" text-anchor=\"middle\" fill=\"{DoorColor}\" font-size=\"8\">Kapı</text>");

        // Dimensions
        var dimY = oy + rh + DimOffset;
        sb.AppendLine($"<line x1=\"{F(ox)}\" y1=\"{F(dimY)}\" x2=\"{F(ox + rw)}\" y2=\"{F(dimY)}\" stroke=\"{DimColor}\" stroke-width=\"0.8\"/>");
        sb.AppendLine($"<text x=\"{F(ox + rw / 2)}\" y=\"{F(dimY + 15)}\" text-anchor=\"middle\" fill=\"{DimColor}\">{roomW} mm</text>");

        sb.AppendLine("</svg>");
        return sb.ToString();
    }

    public string GenerateCabinPlan(Lift lift)
    {
        var sb = new StringBuilder();
        var cabW = lift.KabinGenisligi > 0 ? lift.KabinGenisligi : 1100;
        var cabD = lift.KabinDerinligi > 0 ? lift.KabinDerinligi : 1400;
        var doorW = lift.KapiGenisligi > 0 ? lift.KapiGenisligi : 900;

        var drawW = ViewBoxWidth - 2 * Margin;
        var drawH = ViewBoxHeight - 2 * Margin;
        var scale = Math.Min((double)drawW / cabW, (double)drawH / cabD);
        var cw = cabW * scale;
        var ch = cabD * scale;
        var ox = Margin + (drawW - cw) / 2;
        var oy = Margin + (drawH - ch) / 2;

        sb.AppendLine($"<svg xmlns=\"http://www.w3.org/2000/svg\" viewBox=\"0 0 {ViewBoxWidth} {ViewBoxHeight}\" width=\"{ViewBoxWidth}\" height=\"{ViewBoxHeight}\">");
        sb.AppendLine("<style>text{font-family:Arial,sans-serif;font-size:10px;}</style>");

        // Cabin interior rect
        sb.AppendLine($"<rect x=\"{F(ox)}\" y=\"{F(oy)}\" width=\"{F(cw)}\" height=\"{F(ch)}\" fill=\"#f5f5f5\" stroke=\"{StrokeColor}\" stroke-width=\"2\"/>");

        // Door opening (bottom center)
        var dw = doorW * scale;
        var dx = ox + (cw - dw) / 2;
        sb.AppendLine($"<rect x=\"{F(dx)}\" y=\"{F(oy + ch - 4)}\" width=\"{F(dw)}\" height=\"6\" fill=\"{DoorColor}\" stroke=\"{DoorColor}\" stroke-width=\"1\"/>");
        sb.AppendLine($"<text x=\"{F(dx + dw / 2)}\" y=\"{F(oy + ch + 16)}\" text-anchor=\"middle\" fill=\"{DoorColor}\" font-size=\"9\">Kapı {doorW} mm</text>");

        // Handrail lines (left, right, back walls)
        var hrOffset = 8.0;
        sb.AppendLine($"<line x1=\"{F(ox + hrOffset)}\" y1=\"{F(oy + hrOffset)}\" x2=\"{F(ox + hrOffset)}\" y2=\"{F(oy + ch - hrOffset)}\" stroke=\"#999\" stroke-width=\"1.5\"/>");
        sb.AppendLine($"<line x1=\"{F(ox + cw - hrOffset)}\" y1=\"{F(oy + hrOffset)}\" x2=\"{F(ox + cw - hrOffset)}\" y2=\"{F(oy + ch - hrOffset)}\" stroke=\"#999\" stroke-width=\"1.5\"/>");
        sb.AppendLine($"<line x1=\"{F(ox + hrOffset)}\" y1=\"{F(oy + hrOffset)}\" x2=\"{F(ox + cw - hrOffset)}\" y2=\"{F(oy + hrOffset)}\" stroke=\"#999\" stroke-width=\"1.5\"/>");

        // Button panel (small rect on right wall near door)
        var bpW = cw * 0.06;
        var bpH = ch * 0.2;
        sb.AppendLine($"<rect x=\"{F(ox + cw - hrOffset - bpW)}\" y=\"{F(oy + ch * 0.5)}\" width=\"{F(bpW)}\" height=\"{F(bpH)}\" fill=\"#ffe0b2\" stroke=\"{StrokeColor}\" stroke-width=\"1\"/>");
        sb.AppendLine($"<text x=\"{F(ox + cw - hrOffset - bpW / 2)}\" y=\"{F(oy + ch * 0.5 + bpH + 12)}\" text-anchor=\"middle\" fill=\"{StrokeColor}\" font-size=\"8\">Buton</text>");

        // Dimensions
        var dimY = oy + ch + DimOffset + 10;
        sb.AppendLine($"<line x1=\"{F(ox)}\" y1=\"{F(dimY)}\" x2=\"{F(ox + cw)}\" y2=\"{F(dimY)}\" stroke=\"{DimColor}\" stroke-width=\"0.8\"/>");
        sb.AppendLine($"<text x=\"{F(ox + cw / 2)}\" y=\"{F(dimY + 15)}\" text-anchor=\"middle\" fill=\"{DimColor}\">{cabW} mm</text>");

        var dimX = ox + cw + DimOffset;
        sb.AppendLine($"<line x1=\"{F(dimX)}\" y1=\"{F(oy)}\" x2=\"{F(dimX)}\" y2=\"{F(oy + ch)}\" stroke=\"{DimColor}\" stroke-width=\"0.8\"/>");
        sb.AppendLine($"<text x=\"{F(dimX + 5)}\" y=\"{F(oy + ch / 2)}\" fill=\"{DimColor}\" transform=\"rotate(90,{F(dimX + 5)},{F(oy + ch / 2)})\" text-anchor=\"middle\">{cabD} mm</text>");

        sb.AppendLine("</svg>");
        return sb.ToString();
    }

    public string GenerateGroupCrossSection(List<Lift> lifts, int partitionWallThickness)
    {
        if (lifts == null || lifts.Count == 0)
            return "<svg xmlns=\"http://www.w3.org/2000/svg\" viewBox=\"0 0 600 600\"></svg>";

        var ordered = lifts.OrderBy(l => l.GroupPosition ?? 0).ToList();
        var totalW = ordered.Sum(l => l.KuyuGenisligi > 0 ? l.KuyuGenisligi : 2000)
                     + (ordered.Count - 1) * partitionWallThickness;
        var maxD = ordered.Max(l => l.KuyuDerinligi > 0 ? l.KuyuDerinligi : 2500);

        var drawW = ViewBoxWidth - 2 * Margin;
        var drawH = ViewBoxHeight - 2 * Margin;
        var scale = Math.Min((double)drawW / totalW, (double)drawH / maxD);

        var sb = new StringBuilder();
        sb.AppendLine($"<svg xmlns=\"http://www.w3.org/2000/svg\" viewBox=\"0 0 {ViewBoxWidth} {ViewBoxHeight}\" width=\"{ViewBoxWidth}\" height=\"{ViewBoxHeight}\">");
        sb.AppendLine("<style>text{font-family:Arial,sans-serif;font-size:10px;}</style>");

        var groupW = totalW * scale;
        var groupH = maxD * scale;
        var startX = Margin + (drawW - groupW) / 2;
        var startY = Margin + (drawH - groupH) / 2;

        // Outer boundary
        sb.AppendLine($"<rect x=\"{F(startX)}\" y=\"{F(startY)}\" width=\"{F(groupW)}\" height=\"{F(groupH)}\" fill=\"none\" stroke=\"{StrokeColor}\" stroke-width=\"2\"/>");

        var curX = startX;
        for (int i = 0; i < ordered.Count; i++)
        {
            var lift = ordered[i];
            var sw = (lift.KuyuGenisligi > 0 ? lift.KuyuGenisligi : 2000) * scale;
            var sh = (lift.KuyuDerinligi > 0 ? lift.KuyuDerinligi : 2500) * scale;

            // Cabin outline inside each shaft
            var cabW = (lift.KabinGenisligi > 0 ? lift.KabinGenisligi : (int)(lift.KuyuGenisligi * 0.6)) * scale;
            var cabH = (lift.KabinDerinligi > 0 ? lift.KabinDerinligi : (int)(lift.KuyuDerinligi * 0.55)) * scale;
            var cabX = curX + (sw - cabW) / 2;
            var cabY = startY + (groupH - cabH) / 2;
            sb.AppendLine($"<rect x=\"{F(cabX)}\" y=\"{F(cabY)}\" width=\"{F(cabW)}\" height=\"{F(cabH)}\" fill=\"#f0f0f0\" stroke=\"{StrokeColor}\" stroke-width=\"1\"/>");

            // Label
            sb.AppendLine($"<text x=\"{F(curX + sw / 2)}\" y=\"{F(startY - 8)}\" text-anchor=\"middle\" fill=\"{StrokeColor}\" font-size=\"9\">Asansör {i + 1}</text>");

            curX += sw;

            // Partition wall
            if (i < ordered.Count - 1)
            {
                var wallW = partitionWallThickness * scale;
                sb.AppendLine($"<rect x=\"{F(curX)}\" y=\"{F(startY)}\" width=\"{F(wallW)}\" height=\"{F(groupH)}\" fill=\"#bbb\" stroke=\"{StrokeColor}\" stroke-width=\"0.5\"/>");
                curX += wallW;
            }
        }

        // Total width dimension
        var dimY = startY + groupH + DimOffset;
        sb.AppendLine($"<line x1=\"{F(startX)}\" y1=\"{F(dimY)}\" x2=\"{F(startX + groupW)}\" y2=\"{F(dimY)}\" stroke=\"{DimColor}\" stroke-width=\"0.8\"/>");
        sb.AppendLine($"<text x=\"{F(startX + groupW / 2)}\" y=\"{F(dimY + 15)}\" text-anchor=\"middle\" fill=\"{DimColor}\">{totalW} mm</text>");

        sb.AppendLine("</svg>");
        return sb.ToString();
    }

    public byte[] ExportToDxf(string svgContent, string drawingType)
    {
        var sb = new StringBuilder();

        // DXF header
        sb.AppendLine("0");
        sb.AppendLine("SECTION");
        sb.AppendLine("2");
        sb.AppendLine("HEADER");
        sb.AppendLine("0");
        sb.AppendLine("ENDSEC");

        // Entities section
        sb.AppendLine("0");
        sb.AppendLine("SECTION");
        sb.AppendLine("2");
        sb.AppendLine("ENTITIES");

        // Extract lines from SVG
        var lineRegex = new Regex(@"<line\s+x1=""([^""]+)""\s+y1=""([^""]+)""\s+x2=""([^""]+)""\s+y2=""([^""]+)""", RegexOptions.IgnoreCase);
        foreach (Match m in lineRegex.Matches(svgContent))
        {
            if (double.TryParse(m.Groups[1].Value, NumberStyles.Float, CultureInfo.InvariantCulture, out var x1) &&
                double.TryParse(m.Groups[2].Value, NumberStyles.Float, CultureInfo.InvariantCulture, out var y1) &&
                double.TryParse(m.Groups[3].Value, NumberStyles.Float, CultureInfo.InvariantCulture, out var x2) &&
                double.TryParse(m.Groups[4].Value, NumberStyles.Float, CultureInfo.InvariantCulture, out var y2))
            {
                AppendDxfLine(sb, x1, y1, x2, y2);
            }
        }

        // Extract rects as 4 lines
        var rectRegex = new Regex(@"<rect\s+x=""([^""]+)""\s+y=""([^""]+)""\s+width=""([^""]+)""\s+height=""([^""]+)""", RegexOptions.IgnoreCase);
        foreach (Match m in rectRegex.Matches(svgContent))
        {
            if (double.TryParse(m.Groups[1].Value, NumberStyles.Float, CultureInfo.InvariantCulture, out var x) &&
                double.TryParse(m.Groups[2].Value, NumberStyles.Float, CultureInfo.InvariantCulture, out var y) &&
                double.TryParse(m.Groups[3].Value, NumberStyles.Float, CultureInfo.InvariantCulture, out var w) &&
                double.TryParse(m.Groups[4].Value, NumberStyles.Float, CultureInfo.InvariantCulture, out var h))
            {
                AppendDxfLine(sb, x, y, x + w, y);
                AppendDxfLine(sb, x + w, y, x + w, y + h);
                AppendDxfLine(sb, x + w, y + h, x, y + h);
                AppendDxfLine(sb, x, y + h, x, y);
            }
        }

        // Extract text elements
        var textRegex = new Regex(@"<text[^>]*x=""([^""]+)""[^>]*y=""([^""]+)""[^>]*>([^<]+)</text>", RegexOptions.IgnoreCase);
        foreach (Match m in textRegex.Matches(svgContent))
        {
            if (double.TryParse(m.Groups[1].Value, NumberStyles.Float, CultureInfo.InvariantCulture, out var tx) &&
                double.TryParse(m.Groups[2].Value, NumberStyles.Float, CultureInfo.InvariantCulture, out var ty))
            {
                AppendDxfText(sb, tx, ty, m.Groups[3].Value.Trim());
            }
        }

        sb.AppendLine("0");
        sb.AppendLine("ENDSEC");
        sb.AppendLine("0");
        sb.AppendLine("EOF");

        return Encoding.UTF8.GetBytes(sb.ToString());
    }

    private static void AppendDxfLine(StringBuilder sb, double x1, double y1, double x2, double y2)
    {
        sb.AppendLine("0");
        sb.AppendLine("LINE");
        sb.AppendLine("8");
        sb.AppendLine("0"); // layer
        sb.AppendLine("10");
        sb.AppendLine(x1.ToString("F4", CultureInfo.InvariantCulture));
        sb.AppendLine("20");
        sb.AppendLine(y1.ToString("F4", CultureInfo.InvariantCulture));
        sb.AppendLine("11");
        sb.AppendLine(x2.ToString("F4", CultureInfo.InvariantCulture));
        sb.AppendLine("21");
        sb.AppendLine(y2.ToString("F4", CultureInfo.InvariantCulture));
    }

    private static void AppendDxfText(StringBuilder sb, double x, double y, string text)
    {
        sb.AppendLine("0");
        sb.AppendLine("TEXT");
        sb.AppendLine("8");
        sb.AppendLine("0"); // layer
        sb.AppendLine("10");
        sb.AppendLine(x.ToString("F4", CultureInfo.InvariantCulture));
        sb.AppendLine("20");
        sb.AppendLine(y.ToString("F4", CultureInfo.InvariantCulture));
        sb.AppendLine("40");
        sb.AppendLine("10.0000"); // text height
        sb.AppendLine("1");
        sb.AppendLine(text);
    }

    private static string F(double v) => v.ToString("F2", CultureInfo.InvariantCulture);
}
