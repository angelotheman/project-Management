using System;
using System.Collections.Generic;

namespace ProjectApi.Models.Entities;

public partial class ReportStatus
{
    public int ReportStatusId { get; set; }

    public int ReportId { get; set; }

    public int StatusId { get; set; }

    public DateTime CreatedAt { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime? UpdatedAt { get; set; }

    public string? UpdatedBy { get; set; }

    public bool? IsDeleted { get; set; }

    public virtual Report Report { get; set; } = null!;

    public virtual Status Status { get; set; } = null!;
}
