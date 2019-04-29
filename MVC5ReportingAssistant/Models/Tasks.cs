using MVC5ReportingAssistant.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MVC5ReportingAssistant.Models
{
    public class Tasks
    {
        [Key]
        public int TaskId { get; set; }

        [MaxLength(50)]
        [MinLength(2)]
        public string Screen { get; set; }

        [MaxLength(10000)]
        [MinLength(2)]
        public string Description { get; set; }

        [ForeignKey("ApplicationUserAdmin")]
        public string AdminUserId { get; set; }

        [ForeignKey("ApplicationUser")]
        public string UserId { get; set; }

        public ApplicationUser ApplicationUserAdmin { get; set; }
        public ApplicationUser ApplicationUser { get; set; }

        [Required]
        public DateTime DateOfTask { get; set; }

        [ForeignKey("Project")]
        public int ProjectId { get; set; }

        public virtual Project Project { get; set; }
    }
}