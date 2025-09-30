using Application.Dtos.OptionDtos;

namespace Application.Services
{
    public interface IOptionService
    {
        Task<OptionDto> CreateOptionAsync(OptionCreateDto dto);
        Task<OptionDto> UpdateOptionAsync(OptionUpdateDto dto);
        Task<List<OptionDto>> GetOptionsByQuestionIdAsync(Guid questionId);
    }

}