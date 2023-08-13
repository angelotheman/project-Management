using System.ComponentModel.DataAnnotations;

namespace ProjectApi.Models
{
    public class Report
    {
        [Key]
        public int ReportId { get; set; }
        public string IssueId { get; set; } // Unique ID for tracking the report
        public string FaultDescription { get; set; }
        public DateTime Created_At { get; set; }
        public string Location { get; set; }
        public int? CategoryId { get; set; }
        public Category Category { get; set; }
        public ICollection<Status> Status { get; set; }
        public ICollection<ReportImage> ReportImage { get; set; }

        // This constructor generates a unique key for every report that is instantiated
        public Report()
        {
            this.Status = new HashSet<Status>();
        }
    }
}
