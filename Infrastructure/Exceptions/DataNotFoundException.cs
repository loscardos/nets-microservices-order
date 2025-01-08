namespace OrderService.Infrastructure.Exceptions
{
    public class DataNotFoundException(string message = "Data not found") : Exception(message)
    {
    }
}