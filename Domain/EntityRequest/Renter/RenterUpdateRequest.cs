﻿namespace Domain.EntityRequest.Renter;

public class RenterUpdateRequest
{
    public string Email { get; set; }
    public string? Phone { get; set; }
    public string? PhoneNumber { get; set; }
    public string FullName { get; set; }
    public string BirthDate { get; set; }
    public string Address { get; set; }
    public string Gender { get; set; }
}