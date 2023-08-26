using System;
using System.Collections.Generic;

namespace ProjectApi.Models.Entities;

public partial class Status
{
    public int StatusId { get; set; }

    public string StatusName { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime? UpdatedAt { get; set; }

    public string? UpdatedBy { get; set; }

    public bool? IsDeleted { get; set; }

    public virtual ICollection<ReportStatus> ReportStatuses { get; set; } = new List<ReportStatus>();
}
