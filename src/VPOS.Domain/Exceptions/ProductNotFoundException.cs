using System;

namespace VPOS.Domain.Exceptions
{
    public class ProductNotFoundException : VPOSException
    {
        public ProductNotFoundException(Guid productId) : base($"Product '{productId}' was not found.") => ProductId = productId;
        
        public Guid ProductId { get; }
    }
}
