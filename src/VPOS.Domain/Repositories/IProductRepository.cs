using System;
using System.Threading.Tasks;
using VPOS.Domain.Entities;
using VPOS.Domain.Enums;

namespace VPOS.Domain.Repositories
{
    public interface IProductRepository
    {
        Task<int> GetProductCountByStatusAsync(ProductStatus status);
        Task<Product> GetAsync(Guid id);
        Task AddAsync(Product product);
        Task<bool> UpdateAsync(Product product);
        Task<bool> ProductExists(string name, string barcode);
    }
}
