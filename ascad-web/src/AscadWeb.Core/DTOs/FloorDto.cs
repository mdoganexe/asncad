namespace AscadWeb.Core.DTOs;

public record UpdateFloorsRequest(
    List<FloorInfoDto> Floors
);

public record FloorCalculationResponse(
    List<FloorInfoDto> Floors,
    int TravelDistance,
    int PitDepth,
    int OverheadClearance
);
