using System.ComponentModel.DataAnnotations;

namespace ProjectApi.Models.DTO
{
    public class ReportInputDTO
    {
        public string FaultDescription { get; set; }
        public string ImageUrl { get; set; }
        public Category FaultCategory { get; set; }
        public string Location { get; set; }
    }
}
