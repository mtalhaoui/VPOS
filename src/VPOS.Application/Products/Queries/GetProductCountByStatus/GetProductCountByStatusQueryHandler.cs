using MediatR;
using System.Threading;
using System.Threading.Tasks;
using VPOS.Application.Products.Queries.Service.Interface;

namespace VPOS.Application.Products.Queries.GetProductCountByStatus
{
    public class GetProductCountByStatusQueryHandler : IRequestHandler<GetProductCountByStatusQuery, int>
    {
        private readonly IProductService _productService;

        public GetProductCountByStatusQueryHandler(IProductService productService) => _productService = productService;

        public async Task<int> Handle(GetProductCountByStatusQuery request, CancellationToken cancellationToken) => await _productService.GetProductCountByStatus(request);
    }
}
