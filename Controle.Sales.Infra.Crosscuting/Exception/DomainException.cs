namespace Infra.Cross.Exception
{
    public class DomainException : System.Exception
    {
        public DomainException() : base("Generic Domain Error")
        {
        }

        public DomainException(string message) : base(message)
        {
        }
    }
}
