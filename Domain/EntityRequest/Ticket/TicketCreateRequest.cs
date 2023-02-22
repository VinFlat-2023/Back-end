﻿using System.ComponentModel.DataAnnotations;

namespace Domain.EntityRequest.Ticket;

public class TicketCreateRequest
{
    public string TicketName { get; set; } = null!;
    public string Description { get; set; } = null!;

    [Required] public DateTime CreateDate { get; set; }

    public DateTime? SolveDate { get; set; }
    public decimal? Amount { get; set; }
    public string Status { get; set; } = null!;
    [Required] public int TicketTypeId { get; set; }
}