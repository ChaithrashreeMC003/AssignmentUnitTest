namespace Application.Dtos.SurveyDtos
{
    public class SurveyDto
    {
        public Guid SurveyId { get; set; }
        public string Title { get; set; } = default!;
        public Guid UserId { get; set; }      // from logged-in user
        public Guid ProductId { get; set; }
    }
}
