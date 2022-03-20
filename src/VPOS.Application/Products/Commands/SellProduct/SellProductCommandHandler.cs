using MediatR;
using System.Threading;
using System.Threading.Tasks;
using VPOS.Application.Products.Commands.Service.Interface;

namespace VPOS.Application.Products.Commands.SellProduct
{
    public class SellProductCommandHandler : IRequestHandler<SellProductCommand, bool>
    {
        private readonly IProductService _productService;

        public SellProductCommandHandler(IProductService productService) => _productService = productService;

        public async Task<bool> Handle(SellProductCommand request, CancellationToken cancellationToken) => await _productService.SellProduct(request);
    }
}
