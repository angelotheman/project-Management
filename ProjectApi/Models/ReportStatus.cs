namespace ProjectApi.Models
{
    public class ReportStatus
    {
        public int ReportId { get; set; }
        public int StatusId { get; set; }

        // Navigation Properties defined for many to many
        public Report Report { get; set; }
        public Status Status { get; set; }
    }
}
