using System.ComponentModel.DataAnnotations;

namespace ProjectApi.Models
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }
        public string Name { get; set; }

        // Has one relationship with Report
        public ICollection<Report> Report { get; set; }
    }
}
