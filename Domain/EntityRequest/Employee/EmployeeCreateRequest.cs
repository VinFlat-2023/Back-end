﻿namespace Domain.EntityRequest.Employee;

public class EmployeeCreateRequest
{
    public string Username { get; set; } = null!;
    public string Fullname { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string Phone { get; set; }
    public string PhoneNumber => Phone;
    public string Address { get; set; }
    public int RoleId { get; set; }

    /// <summary>
    ///     Device Token.
    /// </summary>
    public string? DeviceToken { get; set; }

    public int? BuildingId { get; set; }
}