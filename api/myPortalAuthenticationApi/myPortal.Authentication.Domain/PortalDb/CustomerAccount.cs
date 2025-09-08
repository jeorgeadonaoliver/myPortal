using System;
using System.Collections.Generic;

namespace myPortal.Authentication.Domain.PortalDb;

public partial class CustomerAccount
{
    public string? Id { get; set; }

    public string? LastName { get; set; }

    public string? FirstName { get; set; }

    public string? MiddleName { get; set; }

    public string? Email { get; set; }

    public int? RoleId { get; set; }
}
