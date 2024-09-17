namespace StockApp2._0.Exceptions;

public class InsufficientProductQuantityException : Exception
{
    private const string DefaultMessage = "Insufficient quantity of this product for this stock.";
    public InsufficientProductQuantityException() : base(DefaultMessage)
    {
    }

    public InsufficientProductQuantityException(string message) : base(message)
    {
    }
}
