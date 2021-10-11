using GETProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GETProject.ViewModels
{
    public class ProjectFormModel
    {
        public Task Task { get; set; }
        public List<Project> Projects { get; set; }

        public List<User> Users { get; set; }
    }
}