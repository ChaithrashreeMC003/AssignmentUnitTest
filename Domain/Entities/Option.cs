namespace Domain.Entities
{
    public class Option
    {
        public Guid OptionId { get; set; }
        public string OptionValue { get; set; }
        public int Order { get; set; }
        public Guid QuestionId { get; set; }
        public Question Question { get; set; }
    }

}

