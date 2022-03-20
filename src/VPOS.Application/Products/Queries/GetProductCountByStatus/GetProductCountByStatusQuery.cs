using MediatR;
using VPOS.Domain.Enums;

namespace VPOS.Application.Products.Queries.GetProductCountByStatus
{
    public class GetProductCountByStatusQuery : IRequest<int>
    {
        public GetProductCountByStatusQuery(ProductStatus status)
        {
            Status = status;
        }

        public ProductStatus Status { get; private set; }
    }
}
