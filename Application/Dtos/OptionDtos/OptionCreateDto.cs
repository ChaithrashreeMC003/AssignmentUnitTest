namespace Application.Dtos.OptionDtos
{
    public class OptionCreateDto
    {
        public Guid QuestionId { get; set; }
        public string OptionValue { get; set; } = default!;
        public int Order { get; set; }
    }
}
