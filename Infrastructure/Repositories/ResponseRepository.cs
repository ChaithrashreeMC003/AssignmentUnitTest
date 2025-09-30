using Domain.Entities;
using Infrastructure.DbContexts;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class ResponseRepository : IResponseRepository
    {
        private readonly SurveyDbContext _context;

        public ResponseRepository(SurveyDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Response>> GetAllAsync()
        {
            return await _context.Responses
                .Include(r => r.ResponseOptions)
                .ThenInclude(ro => ro.Option)
                .Include(r => r.Question)
                .ToListAsync();
        }

        public async Task<Response> GetByIdAsync(Guid id)
        {
            return await _context.Responses
                .Include(r => r.ResponseOptions)
                .ThenInclude(ro => ro.Option)
                .Include(r => r.Question)
                .FirstOrDefaultAsync(r => r.ResponseId == id);
        }

        public async Task AddAsync(Response response)
        {
            await _context.Responses.AddAsync(response);
        }

        public void Remove(Response response)
        {
            _context.Responses.Remove(response);
        }
    }
}