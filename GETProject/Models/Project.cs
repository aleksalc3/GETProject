using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GETProject.Models
{
    
    public class Project
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Product name is Required")]
        [StringLength(50)]
        [Display(Name ="Project")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Product code is Required")]
        [StringLength(50)]
        public string Code { get; set; }

        public List<Task> Tasks { get; set; }
    }
}