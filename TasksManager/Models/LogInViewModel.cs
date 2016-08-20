using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TasksManager.Models
{
    public class LogInViewModel
    {
        [Required(ErrorMessage = "Enter name")]
        [StringLength(20, MinimumLength = 6)]
        [Display(Name = "Name")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Enter password")]
        [StringLength(20, MinimumLength = 6)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Display(Name = "Remember me")]
        public bool RememberMe { get; set; }
    }
}