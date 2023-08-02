using System.ComponentModel.DataAnnotations;

namespace ProjectApi.Models
{
    public class Status
    {
        [Key]
        public int StatusId { get; set; }
        public string StatusName { get; set; }

        // Many to many with Reports

        public Status()
        {
            this.Report = new HashSet<Report>();
        }

        public virtual ICollection<Report> Report { get; set;}
    }
}
