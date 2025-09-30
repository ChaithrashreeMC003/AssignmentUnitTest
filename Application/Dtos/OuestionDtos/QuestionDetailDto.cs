using Domain.Entities;

namespace Application.Dtos.OuestionDtos
{
    // For GetById
    public class QuestionDetailDto
    {
        public Guid QuestionId { get; set; }
        public string QuestionText { get; set; } = default!;
        public QuestionType QuestionType { get; set; } = default!;
        public bool IsMandatory { get; set; }
        public Guid SurveyId { get; set; }
        public List<Option1Dto> Options { get; set; } = new List<Option1Dto>();
    }
}
