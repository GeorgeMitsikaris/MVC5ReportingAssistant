using Microsoft.AspNet.Identity.EntityFramework;
using MVC5ReportingAssistant.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MVC5ReportingAssistant.Identity
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext() : base("DefaultConnection")
        {
        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Tasks> Tasks { get; set; }
        public DbSet<TasksDone> TasksDone { get; set; }
        public DbSet<FinalComments> FinalComments { get; set; }
    }
}