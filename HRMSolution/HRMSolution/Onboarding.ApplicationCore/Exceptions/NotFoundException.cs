namespace Onboarding.ApplicationCore.Exceptions;

public class NotFoundException : Exception
{
    public NotFoundException()
    {
        
    }

    public NotFoundException(string clazz, string field, object property) : base(
        $"{clazz} ({field} == {property}) is not exist!")
    {

    }
}