using Application.Dtos.ResponseDtos;
using Domain.Entities;

namespace Application.Services
{
    public interface IResponseService
    {
        Task<IEnumerable<ResponseDto>> GetAllAsync();
        Task<ResponseDto> GetByIdAsync(Guid id);
        Task<ResponseDto> CreateAsync(CreateResponseDto dto, Question question);
        Task<ResponseDto> UpdateAsync(Guid id, UpdateResponseDto dto, Question question);
        Task DeleteAsync(Guid id);
    }
}