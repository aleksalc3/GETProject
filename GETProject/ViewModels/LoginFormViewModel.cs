using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GETProject.ViewModels
{
    public class LoginFormViewModel
    {
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
    }
}