using System.Threading.Tasks;
using VPOS.Application.Products.Queries.GetProductCountByStatus;
using VPOS.Application.Products.Queries.Service.Interface;
using VPOS.Domain.Repositories;

namespace VPOS.Application.Products.Queries.Service
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _repository;

        public ProductService(IProductRepository repository) => _repository = repository;

        public async Task<int> GetProductCountByStatus(GetProductCountByStatusQuery query) => await _repository.GetProductCountByStatusAsync(query.Status);
    }
}
