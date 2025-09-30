using Domain.Entities;

namespace Application.Dtos.OuestionDtos
{
    public class CreateQuestionDto
    {
        public string QuestionText { get; set; } = default!;
        public QuestionType QuestionType { get; set; } = default!;
        public bool IsMandatory { get; set; }
        public Guid SurveyId { get; set; }
    }
}
