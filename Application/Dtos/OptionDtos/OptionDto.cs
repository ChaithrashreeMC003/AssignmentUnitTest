using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos.OptionDtos
{

    public class OptionDto
    {
        public Guid OptionId { get; set; }
        public string OptionValue { get; set; } = default!;
        public int Order { get; set; }
        public Guid QuestionId { get; set; }
    }
}
