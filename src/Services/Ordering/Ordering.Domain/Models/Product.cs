namespace Ordering.Domain.Models;

public class Product : Entity<Guid>
{
    #region PROPS :

    public string Name { get; private set; } = default!;
    public decimal Price { get; private set; } = default!;

    #endregion PROPS :
}