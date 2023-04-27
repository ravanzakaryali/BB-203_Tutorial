namespace Exceptions.Exceptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException() : base("Not found Exception")
        {
            
        }
        public NotFoundException(string message) : base(message)
        {
            
        }
    }
}
