using Application.Dtos.OuestionDtos;

namespace Application.Services
{
    public interface IQuestionService
    {
        Task<IEnumerable<QuestionDto>> GetAllAsync();
        Task<QuestionDetailDto?> GetByIdAsync(Guid id);
        Task<QuestionDto?> CreateAsync(CreateQuestionDto dto);
        Task<QuestionDto?> UpdateAsync(Guid id, UpdateQuestionDto dto);
        Task<bool> DeleteAsync(Guid id);
    }

}