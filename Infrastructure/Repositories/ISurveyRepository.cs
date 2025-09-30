using Domain.Entities;

namespace Infrastructure.Repositories
{
    public interface ISurveyRepository
    {
        Task<Survey?> GetByIdAsync(Guid id);
        Task<IEnumerable<Survey>> GetAllAsync();
        Task AddAsync(Survey survey);
        Task UpdateAsync(Survey survey);
        Task DeleteAsync(Guid id);
    }
}