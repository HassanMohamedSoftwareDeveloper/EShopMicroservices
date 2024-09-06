namespace Ordering.Domain.Models;

public class OrderItem : Entity<OrderItemId>
{
    #region CTORS :

    public OrderItem(OrderId orderId, ProductId productId, int quantity, decimal price)
    {
        Id = OrderItemId.Of(Guid.NewGuid());
        OrderId = orderId;
        ProductId = productId;
        Quantity = quantity;
        Price = price;
    }

    #endregion CTORS :

    #region PROPS :

    public OrderId OrderId { get; private set; }
    public ProductId ProductId { get; private set; }
    public int Quantity { get; private set; }
    public decimal Price { get; private set; }

    #endregion PROPS :
}