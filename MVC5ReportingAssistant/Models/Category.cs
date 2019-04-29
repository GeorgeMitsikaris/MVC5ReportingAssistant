using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC5ReportingAssistant.Models
{
    public class Category
    {
        public int CategoryId { get; set; }

        [Required]
        [RegularExpression(@"/[a-zA-Z\s\d]/")]
        public string CategoryName { get; set; }
    }
}