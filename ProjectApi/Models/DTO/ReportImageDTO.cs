namespace ProjectApi.Models.DTO
{
    public class ReportImageDTO
    {
        public int ImageId { get; set; }

        public int ReportId { get; set; }

        public string ImageName { get; set; } = null!;

        public string ImageUrl { get; set; } = null!;
    }

    public class ManipulateReportImageDTO
    {
        public int ReportId { get; set; }
        public string Imagename { get; set; } = null!;
        public string ImageUrl { get; set; } = null!;
    }

    public class CreateReportImageDTO : ManipulateReportImageDTO { }

    public class UpdateReportImageDTO : ManipulateReportImageDTO { }
}
