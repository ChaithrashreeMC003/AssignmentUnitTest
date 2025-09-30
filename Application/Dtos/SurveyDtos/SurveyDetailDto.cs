namespace Application.Dtos.SurveyDtos
{
    public class SurveyDetailDto
    {
        public Guid SurveyId { get; set; }
        public string Title { get; set; } = default!;
        public Guid UserId { get; set; }
        public Guid ProductId { get; set; }

        public ICollection<Question1Dto> Questions { get; set; } = new List<Question1Dto>();
    }
}
