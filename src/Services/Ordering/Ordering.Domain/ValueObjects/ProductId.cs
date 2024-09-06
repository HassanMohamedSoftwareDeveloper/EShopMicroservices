namespace Ordering.Domain.ValueObjects;

public record ProductId
{
    #region PROPS :

    public Guid Value { get; }

    #endregion PROPS :

    #region CTORS :

    private ProductId(Guid value) => Value = value;

    #endregion CTORS :

    #region Methods :

    public static ProductId Of(Guid value)
    {
        ArgumentNullException.ThrowIfNull(value);
        if (value == Guid.Empty)
            throw new DomainException("ProductId cannot be empty.");

        return new ProductId(value);
    }

    #endregion Methods :
}