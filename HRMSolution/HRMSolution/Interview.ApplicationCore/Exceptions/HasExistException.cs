namespace Interview.ApplicationCore.Exceptions;

public class HasExistException : Exception
{
    public HasExistException()
    {
        
    }

    public HasExistException(string clazz, string field, object obj) : base($"{clazz} ({field} == {obj}) has exist in database!")
    {
        
    }
}