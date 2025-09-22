namespace myPortal.Authentication.Application.Usecase.Customer.Query.GetCustomer;

public record GetCustomerQueryDto 
{
    public Guid Id { get; init; }

    public string? LastName { get; init; }

    public string? FirstName { get; init; }

    public string? MiddleName { get; init; }

    public string? Email { get; init; }

    public int? RoleId { get; init; }

    public string Uid { get; init; }

    public DateTime CreatedAt { get; init; } 
}

