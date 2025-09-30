namespace Domain.Entities
{
    public class Question
    {
        public Guid QuestionId { get; set; }
        public string QuestionText { get; set; } 
        public QuestionType QuestionType { get; set; } // MultipleChoice, Checkbox, Text, Rating
                                                                                                      
        public bool IsMandatory { get; set; }
        public Guid SurveyId { get; set; }
        public Survey Survey { get; set; }
        public ICollection<Option> Options { get; set; }
    }
}

