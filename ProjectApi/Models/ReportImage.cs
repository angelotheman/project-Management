﻿using System.ComponentModel.DataAnnotations;

namespace ProjectApi.Models
{
    public class ReportImage
    {
        [Key]
        public int ReportImageId { get; set; }
        public string ImageUrl { get; set; }

        // One to many with Report
        public int ReportId { get; set; }
        public Report Report { get; set; }
    }
}