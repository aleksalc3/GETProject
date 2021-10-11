using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GETProject.Models
{
    public class Task
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Tast status is Required")]
        [StringLength(50)]
        public string Status { get; set; }

        [Display(Name = "Assignee")]
        public int UserId { get; set; }
        public User User { get; set; }
        public int progress { get; set; }

        public DateTime Deadline { get; set; }
        [Required(ErrorMessage = "Tast status is Required")]
        [StringLength(500)]
        public string description { get; set; }

        //Properties
        [Display(Name ="Project")]
        public int ProjectId { get; set; }
        public Project Project { get; set; }

    }
}