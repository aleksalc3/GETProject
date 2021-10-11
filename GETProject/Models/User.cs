using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GETProject.Models
{
    public class User
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Username is Required")]
        [Display(Name = "User Name")]
        [StringLength(100)]
        [MaxLength(100)]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Password is Required")]              
        [StringLength(30)]
        [MaxLength(30)]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public int IsActive { get; set; }
        [Required(ErrorMessage = "Email is Required")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required(ErrorMessage = "Email is Required")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Email is Required")]
        public string Surname { get; set; }

        public int RoleId { get; set; }
        public Role Role { get; set; }
    }
}