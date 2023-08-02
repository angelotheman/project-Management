using System.ComponentModel.DataAnnotations;

namespace ProjectApi.Models.DTO
{
    public class ReportInputDTO
    {
        public string FaultDescription { get; set; }
        public DateTime Created_At { get; set; }
        public string Location { get; set; }
        public int CategoryId { get; set; }
    }
}
