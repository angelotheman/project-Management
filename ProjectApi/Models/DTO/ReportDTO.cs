using System.ComponentModel.DataAnnotations;

namespace ProjectApi.Models.DTO
{
    public class ReportDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "The Name field is required. ")]
        [StringLength(50, ErrorMessage = "The name of the field cannot exceed {1} characters")]
        public string Name { get; set; }

        public double Height { get; set; }
        public string Description { get; set; }
    }
}
