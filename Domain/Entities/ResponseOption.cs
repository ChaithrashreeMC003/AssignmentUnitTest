namespace Domain.Entities
{
    // Join table for handling multiple selected options
    public class ResponseOption { 
        public Guid ResponseId { get; set; } 
        public Response Response { get; set; } 
        public Guid OptionId { get; set; } 
        public Option Option { get; set; } 
    }

}

