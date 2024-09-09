namespace Ordering.Application.Data;

public interface IApplicationDbContext
{
    #region PROPS :

    DbSet<Customer> Customers { get; }
    DbSet<Product> Products { get; }
    DbSet<Order> Orders { get; }
    DbSet<OrderItem> OrderItems { get; }

    #endregion PROPS :

    #region Methods :

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);

    #endregion Methods :
}