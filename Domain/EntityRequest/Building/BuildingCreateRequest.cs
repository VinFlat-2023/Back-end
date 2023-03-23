﻿namespace Domain.EntityRequest.Building;

public class BuildingCreateRequest
{
    public string BuildingName { get; set; } = null!;
    public string Description { get; set; } = null!;
    public decimal? CoordinateX { get; set; }
    public string? ImageUrl { get; set; }
    public decimal? CoordinateY { get; set; }
    public bool? Status { get; set; }
    public int AreaId { get; set; }
    public string BuildingPhoneNumber { get; set; }
}