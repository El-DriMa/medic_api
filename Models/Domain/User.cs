﻿using System;
using System.Collections.Generic;

namespace medic_api.Models.Domain;

public partial class User
{
    public int Id { get; set; }

    public string Username { get; set; } = null!;

    public string PasswordHash { get; set; } = null!;

    public string? Role { get; set; }

    public string? Name { get; set; }

    public int? Orders { get; set; }

    public DateTime? LastLoginDate { get; set; }

    public string? ImageUrl { get; set; }

    public string? Status { get; set; }

    public DateTime? DateOfBirth { get; set; }
}