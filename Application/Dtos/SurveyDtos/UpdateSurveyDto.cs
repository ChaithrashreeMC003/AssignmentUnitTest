namespace Application.Dtos.SurveyDtos
{
    public class UpdateSurveyDto
    {
        public string Title { get; set; } = default!;
        public Guid ProductId { get; set; }
    }
}
