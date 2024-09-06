namespace Ordering.Domain.Models;

public class Customer : Entity<CustomerId>
{
    #region PROPS :

    public string Name { get; private set; } = default!;
    public string Email { get; private set; } = default!;

    #endregion PROPS :

    #region Methods :

    public static Customer Create(CustomerId id, string name, string email)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(name);
        ArgumentException.ThrowIfNullOrWhiteSpace(email);

        return new Customer
        {
            Id = id,
            Name = name,
            Email = email
        };
    }

    #endregion Methods :
}