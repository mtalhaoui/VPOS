using System.Threading.Tasks;
using VPOS.Application.Products.Queries.GetProductCountByStatus;

namespace VPOS.Application.Products.Queries.Service.Interface
{
    public interface IProductService
    {
        Task<int> GetProductCountByStatus(GetProductCountByStatusQuery query);
    }
}
