namespace Ordering.Domain.Models;

public class Customer : Entity<CustomerId>
{
    #region PROPS :

    public string Name { get; private set; } = default!;
    public string Email { get; private set; } = default!;

    #endregion PROPS :
}