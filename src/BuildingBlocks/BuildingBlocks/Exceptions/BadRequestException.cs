namespace BuildingBlocks.Exceptions;

public class BadRequestException : Exception
{
    #region CTORS :

    public BadRequestException(string message) : base(message)
    {
    }

    public BadRequestException(string message, string details) : base(message)
    {
        Details = details;
    }

    #endregion CTORS :

    #region PROPS :

    public string? Details { get; }

    #endregion PROPS :
}