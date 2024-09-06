namespace Ordering.Domain.ValueObjects;

public record OrderItemId
{
    #region PROPS :

    public Guid Value { get; }

    #endregion PROPS :

    #region CTORS :

    private OrderItemId(Guid value) => Value = value;

    #endregion CTORS :

    #region Methods :

    public static OrderItemId Of(Guid value)
    {
        ArgumentNullException.ThrowIfNull(value);
        if (value == Guid.Empty)
            throw new DomainException("OrderItemId cannot be empty.");

        return new OrderItemId(value);
    }

    #endregion Methods :
}