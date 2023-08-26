using System;
using System.Collections.Generic;

namespace ProjectApi.Models.Entities;

public partial class Report
{
    public int ReportId { get; set; }

    public int CategoryId { get; set; }

    public string IssueId { get; set; } = null!;

    public string FaultDescription { get; set; } = null!;

    public string Location { get; set; } = null!;

    public bool? IsDeleted { get; set; }

    public DateTime CreatedAt { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime? UpdatedAt { get; set; }

    public string? UpdatedBy { get; set; }

    public virtual Category Category { get; set; } = null!;

    public virtual ICollection<ReportImage> ReportImages { get; set; } = new List<ReportImage>();

    public virtual ICollection<ReportStatus> ReportStatuses { get; set; } = new List<ReportStatus>();
}
