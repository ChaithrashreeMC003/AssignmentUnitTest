namespace Application.Dtos.SurveyDtos
{
    public class Question1Dto
    {
        public Guid QuestionId { get; set; }
        public string QuestionText { get; set; } = default!;
    }
}
