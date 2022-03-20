using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using VPOS.Application.Common.Response;
using VPOS.Application.Products.Commands.Service.Interface;
using VPOS.Domain.Entities;

namespace VPOS.Application.Products.Commands.CreateProduct
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, CommandResponse>
    {
        private readonly IProductService _productService;

        public CreateProductCommandHandler(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<CommandResponse> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            try
            {
                if (request == null)
                    throw new ArgumentNullException();


                var productModel = new Product
                {
                    Id = Guid.NewGuid(),
                    Name = request.Name,
                    Barcode = request.Barcode,
                    Description = request.Description,
                    Weight = request.Weight
                };

                var product = await _productService.CreateProduct(productModel);

                return new CommandResponse(true, $"Product '{productModel.Name}' has been added.");
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
