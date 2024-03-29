﻿namespace Domain.EntityRequest.Service;

public class ServiceCreateRequest
{
    public string Name { get; set; }
    public string Description { get; set; }
    public bool Status { get; set; }
    public decimal Price { get; set; }
    public int ServiceTypeId { get; set; }
}