namespace ProjectApi.Models
{
    public class Report
    {
        public int Id { get; set; }
        public string IssueId { get; private set; } // Unique ID for tracking the report
        public string FaultDescription { get; set; }
        public string ImageUrl { get; set; }
        public Category FaultCategory { get; set; }
        public Status FaultStatus { get; set; }
        public DateTime Created_At { get; set; }
        public string Location { get; set; }

        // Foreign key to link Report to the User who submitted it
        public int UserId { get; set; }
        public User User { get; set; }

        // This constructor generates a unique key for every report that is instantiated
        public Report()
        {
            IssueId = GenerateUniqueIssue();
        }

        // This returns a unique id in the form REPORT-xxxxxxxxxx (7)
        private string GenerateUniqueIssue()
        {
            int issueIdLength = 7;
            return $"REPORT-{GenerateRandomAlphanumericString(issueIdLength)}";
        }

        // This code generates the random characters from the alphanumeric table
        private string GenerateRandomAlphanumericString(int length)
        {
            const string alphanumericChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var random = new Random();
            return new string(Enumerable.Repeat(alphanumericChars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }
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
}
