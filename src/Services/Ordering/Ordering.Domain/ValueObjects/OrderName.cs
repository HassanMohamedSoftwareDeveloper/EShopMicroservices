namespace Ordering.Domain.ValueObjects;

public record OrderName
{
    #region Fields :

    private const int DefaultLength = 5;

    #endregion Fields :

    #region PROPS :

    public string Value { get; } = default!;

    #endregion PROPS :

    #region CTORS :

    private OrderName(string value) => Value = value;

    #endregion CTORS :

    #region Methods :

    public static OrderName Of(string value)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(value);
        ArgumentOutOfRangeException.ThrowIfNotEqual(value.Length, DefaultLength);

        return new OrderName(value);
    }

    #endregion Methods :
}