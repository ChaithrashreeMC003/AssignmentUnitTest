namespace Domain.Entities
{
    public class User
    {
        public Guid Id { get; set; } // GUID for unique ID
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int RoleId { get; set; }
        public Role Role { get; set; }  // Navigation property
        public string Address { get; set; } 
        public ICollection<Survey> Surveys { get; set; }
        public ICollection<UserSurvey> UserSurveys { get; set; } 
    }

}

