using MediatR;
using System;

namespace VPOS.Application.Products.Commands.SellProduct
{
    public class SellProductCommand : IRequest<bool>
    {
        public SellProductCommand(Guid productId)
        {
            ProductId = productId;
        }

        public Guid ProductId { get; private set; }
    }
}
