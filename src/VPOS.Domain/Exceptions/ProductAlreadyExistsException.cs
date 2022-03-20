namespace VPOS.Domain.Exceptions
{
    public class ProductAlreadyExistsException : VPOSException
    {
        public ProductAlreadyExistsException(string name, string barcode) : base($"Product '{name}' already exists with barcode '{barcode}'.")
        {
            Name = name;
            Barcode = barcode;
        }

        public string Name { get; }
        public string Barcode { get; }
    }
}
