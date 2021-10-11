using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace GETProject.Models
{
    public class ProjectContext: DbContext
    {
        
        public DbSet<Project> Projects { get; set; }
        public DbSet<Task> Tasks { get; set; }

        public DbSet<Role> Roles { get; set; }

        public DbSet<User> Users { get; set; }
    }
}