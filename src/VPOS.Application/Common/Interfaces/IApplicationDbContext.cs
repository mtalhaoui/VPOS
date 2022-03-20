using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;
using VPOS.Domain.Entities;

namespace VPOS.Application.Common.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<Product> Products { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
