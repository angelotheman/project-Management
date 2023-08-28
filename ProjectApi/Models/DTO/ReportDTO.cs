using System.ComponentModel.DataAnnotations;

namespace ProjectApi.Models.DTO
{
    public class ReportDTO
    {
        public int ReportId { get; set; }

        public int CategoryId { get; set; }

        public string IssueId { get; set; } = null!;

        public string FaultDescription { get; set; } = null!;

        public string Location { get; set; } = null!;
    }

    public class CreateReportImage
    {
        public string ImageName { get; set; } = null!;
        public string ImageUrl { get; set; } = null!;
    }

    public class ManipulateReportDTO
    {
        public int CategoryId { get; set; }

        public string FaultDescription { get; set; } = null!;

        public string Location { get; set; } = null!;
    }

    public class CreateReportDTO : ManipulateReportDTO
    {
        public CreateReportImage Image { get; set; } = new CreateReportImage();
    }

    public class UpdateReportDTO : ManipulateReportDTO { }
}
