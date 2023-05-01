namespace Onboarding.ApplicationCore.Exceptions;

public class HasExistException : Exception
{
    public HasExistException()
    {
        
    }

    public HasExistException(string clazz, string field, object property) : base(
        $"{clazz} ({field} == {property}) has existed in your database!")
    {

    }
}