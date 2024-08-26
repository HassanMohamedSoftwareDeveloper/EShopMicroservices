namespace BuildingBlocks.Exceptions;

public class InternalServerException : Exception
{
    #region CTORS :

    public InternalServerException(string message) : base(message)
    {
    }

    public InternalServerException(string message, string details) : base(message)
    {
        Details = details;
    }

    #endregion CTORS :

    #region PROPS :

    public string? Details { get; }

    #endregion PROPS :
}