namespace ProjectApi.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Contact { get; set; }
        public string Email { get; set; }

        // Has one to many relationship with the Report Class
        public ICollection<Report> Report { get; set; }
    }
}
