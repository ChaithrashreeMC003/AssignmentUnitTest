using Domain.Entities;

namespace Infrastructure.Repositories
{
    public interface IQuestionRepository
    {
        Task<IEnumerable<Question>> GetAllAsync();
        Task<Question?> GetByIdAsync(Guid id);
        Task<Question> AddAsync(Question question);
        Task<Question?> UpdateAsync(Question question);
        Task<bool> DeleteAsync(Guid id);
        Task<bool> SurveyExistsAsync(Guid surveyId);
    }
}
