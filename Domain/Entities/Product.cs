namespace Domain.Entities
{
    public class Product
    {
        public Guid ProductId { get; set; } // GUID ID
        public string ProductName { get; set; }
        public ICollection<Survey> Surveys { get; set; } 
    }

}

