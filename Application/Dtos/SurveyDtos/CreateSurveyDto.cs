using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos.SurveyDtos
{
    public class CreateSurveyDto
    {
        public string Title { get; set; } = default!;
        public Guid ProductId { get; set; }   // product is chosen while creating
    }
}
