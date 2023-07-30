using System.ComponentModel;

namespace ProjectApi.Models
{
    public class Report
    {
        public int Id { get; set; }
        public string FaultDescription { get; set; }
        public string ImageUrl { get; set; }
        public Category FaultCategory { get; set; }
        public Status FaultStatus { get; set; }
        public DateTime Created_At { get; set; }
        public User User { get; set; }
    }

    public enum Category
    {
        AirCondition,
        Plumbing,
        Carpentry,
        Electricals,
        Building,
        Materials
    }

    public enum Status
    {
        Pending,
        InProgress,
        Completed
    }

    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Contact { get; set; }
        public string Email { get; set; }
    }
}
