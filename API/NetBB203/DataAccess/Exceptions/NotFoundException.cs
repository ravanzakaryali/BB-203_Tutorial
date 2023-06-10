namespace DataAccess.Exceptions;

public class NotFoundException : Exception
{
    public NotFoundException() : base("Not found exception") { }
    public NotFoundException(string message) : base(message) { }
}
