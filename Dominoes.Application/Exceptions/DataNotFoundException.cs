namespace Dominoes.Application.Exceptions;

public class DataNotFoundException : KeyNotFoundException
{
    public DataNotFoundException(string message): base(message)
    {
    }
}