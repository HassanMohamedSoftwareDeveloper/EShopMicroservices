namespace Ordering.Domain.ValueObjects;
public record CustomerId
{
    #region PROPS :

    public Guid Value { get; }

    #endregion PROPS :

    #region CTORS :

    private CustomerId(Guid value) => Value = value;

    #endregion CTORS :

    #region Methods :

    public static CustomerId Of(Guid value)
    {
        ArgumentNullException.ThrowIfNull(value);
        if (value == Guid.Empty)
            throw new DomainException("CustomerId cannot be empty.");

        return new CustomerId(value);
    }

    #endregion Methods :
}