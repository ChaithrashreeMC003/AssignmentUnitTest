using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos.UserDtos
{

        public record UserResponseDto
        {
            public Guid Id { get; set; }
            public string Name { get; set; } = default!;
            public string Email { get; set; } = default!;
            public int RoleId { get; set; }
            public string? RoleName { get; set; }  // Optional, can map from Role entity
            public string Address { get; set; } = default!;
        }
}
