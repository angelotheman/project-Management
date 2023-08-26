using System;
using System.Collections.Generic;

namespace ProjectApi.Models.Entities;

public partial class ReportImage
{
    public int ImageId { get; set; }

    public int ReportId { get; set; }

    public string ImageName { get; set; } = null!;

    public string ImageUrl { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime? UpdatedAt { get; set; }

    public string? UpdatedBy { get; set; }

    public bool? IsDeleted { get; set; }

    public virtual Report Report { get; set; } = null!;
}
