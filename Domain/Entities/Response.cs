namespace Domain.Entities
{
    public class Response
    {
        public Guid ResponseId { get; set; }
        public Guid UserSurveyId { get; set; }
        public UserSurvey UserSurvey { get; set; }
        public Guid QuestionId { get; set; }
        public Question Question { get; set; } 
        public string? FeedbackText { get; set; } // for text answers
        public int? Rating { get; set; }
        public ICollection<ResponseOption> ResponseOptions { get; set; } 
    }

}

