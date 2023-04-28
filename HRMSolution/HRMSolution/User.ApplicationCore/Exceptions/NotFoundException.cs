using System;
namespace User.ApplicationCore.Exceptions;

public class NotFoundException :  Exception
{

    public NotFoundException()
    {
        
    }

    public NotFoundException(string message) : base(message)
    {
        
    }

    public NotFoundException(String message, Exception innerException) : base(message, innerException)
    {
        
    }

    public NotFoundException(string name, object key) : base($"Entity \"{name}\" ({key}) was not found.")
    {
        
    }
    
}