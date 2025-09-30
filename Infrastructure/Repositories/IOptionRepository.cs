using Domain.Entities;

namespace Infrastructure.Repositories
{
    public interface IOptionRepository
    {
        Task<Option?> GetByIdAsync(Guid id);
        Task<List<Option>> GetByQuestionIdAsync(Guid questionId);
        Task AddAsync(Option option);
        Task UpdateAsync(Option option);
        Task SaveChangesAsync();
    }
}