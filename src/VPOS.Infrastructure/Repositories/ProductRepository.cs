using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VPOS.Domain.Entities;
using VPOS.Domain.Enums;
using VPOS.Domain.Repositories;
using VPOS.Infrastructure.Persistence;

namespace VPOS.Infrastructure.Repositories
{
    public class ProductRepository : IProductRepository
    {
        protected ApplicationDbContext _context;

        public ProductRepository(ApplicationDbContext context) => _context = context;

        public async Task<int> GetProductCountByStatusAsync(ProductStatus status) => await _context.Products.Where(q => q.Status == status).CountAsync();

        public async Task<Product> GetAsync(Guid id) => await _context.Products.FindAsync(id);

        public async Task AddAsync(Product product)
        {
            if (product == null)
                throw new ArgumentNullException(nameof(Product));

            try
            {
                await _context.Products.AddAsync(product);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException exception)
            {
                throw new Exception(GetFullErrorTextAndRollbackEntityChanges(exception), exception);
            }
        }

        public async Task<bool> UpdateAsync(Product product)
        {
            if (product == null)
                throw new ArgumentNullException(nameof(Product));

            try
            {
                _context.Entry(product).State = EntityState.Modified;
                return await _context.SaveChangesAsync() > 0;
            }
            catch (DbUpdateException exception)
            {
                throw new Exception(GetFullErrorTextAndRollbackEntityChanges(exception), exception);
            }
        }

        public async Task<bool> ProductExists(string name, string barcode)
        {
            var product = await _context.Products.SingleOrDefaultAsync(q => q.Name == name && q.Barcode == barcode);

            return product is not null;
        }

        #region Utilities

        protected string GetFullErrorTextAndRollbackEntityChanges(DbUpdateException exception)
        {
            if (_context is DbContext dbContext)
            {
                var entries = dbContext.ChangeTracker.Entries()
                    .Where(e => e.State == EntityState.Added || e.State == EntityState.Modified).ToList();

                entries.ForEach(entry =>
                {
                    try
                    {
                        entry.State = EntityState.Unchanged;
                    }
                    catch (InvalidOperationException)
                    {
                        // ignored
                    }
                });
            }

            try
            {
                _context.SaveChanges();
                return exception.ToString();
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
        }

        #endregion
    }
}
