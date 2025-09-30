using Domain.Entities;
using System;

namespace Infrastructure.Repositories
{
    public interface IProductRepository : IGenericRepository<Product>
    {
        // Add custom queries if needed, e.g., search by name
        Task<IEnumerable<Product>> GetByNameAsync(string name);
    }
}
