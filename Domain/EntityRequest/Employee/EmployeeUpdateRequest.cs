﻿using System.ComponentModel.DataAnnotations;

namespace Domain.EntityRequest.Employee;

public class EmployeeUpdateRequest
{
    [StringLength(100, MinimumLength = 6, ErrorMessage = "Username length must be 6-35")]
    [RegularExpression("^[a-zA-Z0-9]{6,100}$", ErrorMessage = "Username only accept alphabet characters and numbers")]
    public string? Username { get; set; }

    public string? Address { get; set; }
    [DataType(DataType.EmailAddress)] public string? Email { get; set; }
    public string? Fullname { get; set; }
    public string? Phone { get; set; }
}