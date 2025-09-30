using Domain.Entities;
using Infrastructure.DbContexts;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        public ProductRepository(SurveyDbContext context) : base(context) { }

        public async Task<IEnumerable<Product>> GetByNameAsync(string name)
        {
            return await _dbSet.Where(p => p.ProductName.Contains(name)).ToListAsync();
        }
    }
}
