namespace StockApp2._0.Exceptions;

public class InvalidBatchException : Exception
{
    private const string DefaultMessage = "Incorrect or inconsistent attributes for batch creation.";

    public InvalidBatchException() : base(DefaultMessage)
    {
    }

    public InvalidBatchException(string message) : base(message)
    {
    }
}
