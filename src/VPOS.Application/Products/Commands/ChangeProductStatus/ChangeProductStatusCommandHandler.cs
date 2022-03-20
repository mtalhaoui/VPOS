using MediatR;
using System.Threading;
using System.Threading.Tasks;
using VPOS.Application.Products.Commands.Service.Interface;

namespace VPOS.Application.Products.Commands.ChangeProductStatus
{
    public class ChangeProductStatusCommandHandler : IRequestHandler<ChangeProductStatusCommand, bool>
    {
        private readonly IProductService _productService;

        public ChangeProductStatusCommandHandler(IProductService productService) => _productService = productService;

        public async Task<bool> Handle(ChangeProductStatusCommand request, CancellationToken cancellationToken) => await _productService.ChangeProductStatus(request);
    }
}
