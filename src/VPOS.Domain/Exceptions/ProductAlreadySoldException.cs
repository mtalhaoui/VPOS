namespace VPOS.Domain.Exceptions
{
    public class ProductAlreadySoldException : VPOSException
    {
        public ProductAlreadySoldException(string name) : base($"Product '{name}' was already sold and is not in stock.")
        {
        }
    }
}
