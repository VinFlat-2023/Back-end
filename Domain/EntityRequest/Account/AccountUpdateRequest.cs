﻿using System.ComponentModel.DataAnnotations;

namespace Domain.EntityRequest.Account;

public class AccountUpdateRequest
{
    [StringLength(100, MinimumLength = 6, ErrorMessage = "Username length must be 6-35")]
    [RegularExpression("^[a-zA-Z0-9]{6,100}$", ErrorMessage = "Username only accept alphabet characters and numbers")]
    public string? Username { get; set; }

    [DataType(DataType.Password)] public string? Password { get; set; }

    [DataType(DataType.EmailAddress)] public string? Email { get; set; }

    public string? Fullname { get; set; } = null!;
    public string? Phone { get; set; } = null!;

    public bool? Status { get; set; }
}