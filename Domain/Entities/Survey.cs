namespace Domain.Entities
{
    public class Survey
    {
        public Guid SurveyId { get; set; }
        public string Title { get; set; }
        public Guid UserId { get; set; } // Creator

        public User User { get; set; }
        public Guid ProductId { get; set; }
        public Product Product { get; set; }
        public ICollection<Question> Questions { get; set; }
        public ICollection<UserSurvey> UserSurveys { get; set; } 
    }

}

