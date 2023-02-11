﻿using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Http;

namespace Domain.EntityRequest.Contract;

public class ContractCreateRequest
{
    public string? ContractName { get; set; }
    public DateTime DateSigned { get; set; }
    public DateTime StartDate { get; set; }
    public string? Description { get; set; }
    public DateTime? EndDate { get; set; }
    public string? ContractStatus { get; set; }
    public string? ImageUrl { get; set; }
    [NotMapped] public IFormFile? Image { get; set; }
    public double Price { get; set; }
    public int RenterId { get; set; }
}