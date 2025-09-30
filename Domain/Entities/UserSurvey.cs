namespace Domain.Entities
{
    public class UserSurvey { 
        public Guid UserSurveyId { get; set; } 
        public Guid UserId { get; set; }
        public User User { get; set; }
        public Guid SurveyId { get; set; } 
        public Survey Survey { get; set; }
        public ICollection<Response> Responses { get; set; } 
    }

}

