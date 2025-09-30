namespace Application.Dtos.OuestionDtos
{
    public class UpdateQuestionDto
    {
        public string QuestionText { get; set; } = default!;
        public bool IsMandatory { get; set; }
    }
}
