using System;
using System.Threading.Tasks;
using VPOS.Application.Products.Commands.ChangeProductStatus;
using VPOS.Application.Products.Commands.SellProduct;
using VPOS.Domain.Entities;

namespace VPOS.Application.Products.Commands.Service.Interface
{
    public interface IProductService
    {
        Task<Product> GetProduct(Guid id);
        Task<Product> CreateProduct(Product product);
        Task<bool> SellProduct(SellProductCommand command);
        Task<bool> ChangeProductStatus(ChangeProductStatusCommand command);
    }
}
