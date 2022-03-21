namespace VPOS.Domain.Exceptions
{
    public class ProductIsDamagedException : VPOSException
    {
        public ProductIsDamagedException(string name) : base($"Product '{name}' is damaged and can\'t be sold.")
        {
        }
    }
}
