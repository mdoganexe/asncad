namespace AscadWeb.Core.Entities;

/// <summary>
/// Stores a CAD drawing's JSON content for a specific lift and drawing type.
/// </summary>
public class Drawing : BaseEntity
{
    public Guid LiftId { get; set; }
    public string DrawingType { get; set; } = string.Empty; // cross-section, longitudinal, etc.
    public string JsonContent { get; set; } = "{}";
    public int Version { get; set; } = 1;

    // Navigation
    public Lift Lift { get; set; } = null!;
}
