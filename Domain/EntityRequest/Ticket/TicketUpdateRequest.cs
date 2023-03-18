﻿namespace Domain.EntityRequest.Ticket;

public class TicketUpdateRequest
{
    public string? Description { get; set; }
    public string? CreateDate { get; set; }
    public string? SolveDate { get; set; }
    public decimal? Amount { get; set; }
    public string? ImageUrl { get; set; }
    public string? Status { get; set; }
    public int? TicketTypeId { get; set; }
}