using MediatR;
using System;
using VPOS.Domain.Enums;

namespace VPOS.Application.Products.Commands.ChangeProductStatus
{
    public class ChangeProductStatusCommand : IRequest<bool>
    {
        public ChangeProductStatusCommand(Guid productId, ProductStatus status)
        {
            ProductId = productId;
            Status = status;
        }

        public Guid ProductId { get; private set; }
        public ProductStatus Status { get; private set; }
    }
}
