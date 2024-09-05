namespace Ordering.Domain.Models;

public class Order : Aggregate<Guid>
{
    #region Fields :

    private readonly List<OrderItem> _orderItems = [];

    #endregion Fields :

    #region PROPS :

    public IReadOnlyList<OrderItem> OrderItems => _orderItems.AsReadOnly();
    public Guid CustomerId { get; private set; } = default!;
    public string OrderName { get; private set; } = default!;
    public Address ShippingAddress { get; private set; } = default!;
    public Address BillingAddress { get; private set; } = default!;
    public Payment Payment { get; private set; } = default!;
    public OrderStatus Status { get; private set; } = OrderStatus.Pending;

    public decimal TotalPrice
    {
        get => OrderItems.Sum(x => x.TotalPrice);
        private set { }
    }

    #endregion PROPS :
}