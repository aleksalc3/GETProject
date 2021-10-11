using GETProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GETProject.ViewModels
{
    public class UserViewModel
    {
        public User User { get; set; }
        public List<Role> Roles { get; set; }

        
    }
}