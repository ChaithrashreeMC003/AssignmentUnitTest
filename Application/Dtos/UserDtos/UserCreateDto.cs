using System.ComponentModel.DataAnnotations;

namespace Application.Dtos.UserDtos
{
    public record UserCreateDto
    {

        public string Name { get; set; } = default!;
        public string Email { get; set; } = default!;
        public string Password { get; set; } = default!;
        public int RoleId { get; set; }
        public string Address { get; set; } = default!;
    }
}
