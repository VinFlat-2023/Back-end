﻿namespace Domain.EntityRequest.Area;

public class AreaUpdateRequest
{
    public string Name { get; set; }

    //public string Location { get; set; }
    public bool Status { get; set; }
    public string? ImageUrl { get; set; }
    public string? ImageUrl2 { get; set; }
    public string? ImageUrl3 { get; set; }
    public string? ImageUrl4 { get; set; }
}