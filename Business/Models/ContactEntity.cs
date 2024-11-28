﻿using Business.Helpers;

namespace Business.Models;

public class ContactEntity
{
    public string Id { get; set; } = null!;
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string PhoneNumber { get; set; } = null!;
    public string Address { get; set; } = null!;
    public int PostalCode { get; set; }
    public string City { get; set; } = null!;
}
