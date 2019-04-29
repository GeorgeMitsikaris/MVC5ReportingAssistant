using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MVC5ReportingAssistant.Models
{
    public class Project
    {
        public int ProjectId { get; set; }

        [Required]
        [RegularExpression(@"/[a-zA-Z\s\d]/")]
        public string ProjectName { get; set; }

        public DateTime? DateOfStart { get; set; }

        public string AvailabilityStatus { get; set; }

        [ForeignKey("Category")]
        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }

    }
}