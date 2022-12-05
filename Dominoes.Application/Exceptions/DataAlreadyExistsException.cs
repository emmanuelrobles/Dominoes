using System.Data;

namespace Dominoes.Application.Exceptions;

public class DataAlreadyExistsException : DuplicateNameException
{
    public DataAlreadyExistsException(string message) : base(message)
    {
        
    }
}