using Application.Dtos.UserDtos;

namespace Application.Services
{
    public interface IUserService
    {
        Task<UserResponseDto> AddUserAsync(UserCreateDto dto);
        Task<UserResponseDto?> GetUserByIdAsync(Guid id);
        Task<IEnumerable<UserResponseDto>> GetAllUsersAsync();
        Task<UserResponseDto?> UpdateUserAsync(Guid id, UserUpdateDto dto);
        Task<UserResponseDto?> DeleteUserAsync(Guid id);
    }
}