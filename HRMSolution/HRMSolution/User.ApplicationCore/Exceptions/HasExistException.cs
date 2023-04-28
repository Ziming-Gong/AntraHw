namespace User.ApplicationCore.Exceptions;

public class HasExistException : Exception
{
    public HasExistException()
    {
        
    }

    public HasExistException(string message) : base(message)
    {
        
    }

    public HasExistException(string clazz, string field, object obj) 
        : base($"Oops! \"{clazz}\" ({field} = {obj}) has exist in the database!")
    {
    }
}