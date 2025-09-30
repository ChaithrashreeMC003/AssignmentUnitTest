using System.ComponentModel.DataAnnotations;

namespace Application.Dtos.UserDtos
{
    public record UserUpdateDto
        {
            public string Name { get; set; } = default!;
            public string Email { get; set; } = default!;
            public string? Password { get; set; }  // Optional, only update if provided
            public string Address { get; set; } = default!;
        }
}
