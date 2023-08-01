namespace ProjectApi.Models
{
    public class Report
    {
        public int ReportId { get; set; }
        public string IssueId { get; private set; } // Unique ID for tracking the report
        public string FaultDescription { get; set; }
        public DateTime Created_At { get; set; }
        public string Location { get; set; }

        
        /* Has one to many relationship with User, Category
         * Has many relationship with Status. This is defined in the constructor and ICollection class
         */

        public int UserId { get; set; }
        public User User { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public ICollection<Status> Status { get; set; }
        public ICollection<ReportImage> ReportImage { get; set; }

        // This constructor generates a unique key for every report that is instantiated
        public Report()
        {
            this.Status = new HashSet<Status>();
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
}
