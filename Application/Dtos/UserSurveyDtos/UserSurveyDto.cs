using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos.UserSurveyDtos
{
    public class UserSurveyDto
    {
        public Guid UserSurveyId { get; set; }
        public Guid UserId { get; set; }
        public Guid SurveyId { get; set; }
    }
}
