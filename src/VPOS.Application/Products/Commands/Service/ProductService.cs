using System;
using System.Threading.Tasks;
using VPOS.Application.Common.Exceptions;
using VPOS.Application.Products.Commands.ChangeProductStatus;
using VPOS.Application.Products.Commands.SellProduct;
using VPOS.Application.Products.Commands.Service.Interface;
using VPOS.Domain.Entities;
using VPOS.Domain.Enums;
using VPOS.Domain.Exceptions;
using VPOS.Domain.Repositories;

namespace VPOS.Application.Products.Commands.Service
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _repository;

        public ProductService(IProductRepository repository) => _repository = repository;

        public async Task<Product> GetProduct(Guid id) => await _repository.GetAsync(id);

        public async Task<Product> CreateProduct(Product product)
        {
            if (await _repository.ProductExists(product.Name, product.Barcode))
                throw new ProductAlreadyExistsException(product.Name, product.Barcode);

            await _repository.AddAsync(product);
            return product;
        }

        public async Task<bool> SellProduct(SellProductCommand command)
        {
            var product = await _repository.GetAsync(command.ProductId);

            if (product == null)
                throw new ProductNotFoundException(command.ProductId);

            if (product.Status == ProductStatus.Sold)
            {
                throw new ProductAlreadySoldException(product.Name);
            }
            else if (product.Status == ProductStatus.Damaged)
            {
                throw new ProductIsDamagedException(product.Name);
            }

            product.ChangeStatus(ProductStatus.Sold);

            return await _repository.UpdateAsync(product);
        }

        public async Task<bool> ChangeProductStatus(ChangeProductStatusCommand command)
        {
            var product = await _repository.GetAsync(command.ProductId);

            product.ChangeStatus(command.Status);

            return await _repository.UpdateAsync(product);
        }
    }
}
