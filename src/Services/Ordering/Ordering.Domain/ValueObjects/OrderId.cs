namespace Ordering.Domain.ValueObjects;

public record OrderId
{
    #region PROPS :

    public Guid Value { get; }

    #endregion PROPS :

    #region CTORS :

    private OrderId(Guid value) => Value = value;

    #endregion CTORS :

    #region Methods :

    public static OrderId Of(Guid value)
    {
        ArgumentNullException.ThrowIfNull(value);
        if (value == Guid.Empty)
            throw new DomainException("OrderId cannot be empty.");

        return new OrderId(value);
    }

    #endregion Methods :
}