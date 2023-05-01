namespace Interview.ApplicationCore.Exceptions;

public class NotFoundException : Exception
{
	public NotFoundException(string clazz, string field, object obj) : base(
		$"{clazz} ({field} == {obj}) has exist in database!")
	{

	}

	public NotFoundException()
	{
		
	}
}
	