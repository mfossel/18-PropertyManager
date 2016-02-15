using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PropertyManager.API.Models
{
    public class RegistrationModel
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string EmailAddress { get; set; }

        [Required]
        [StringLength(64, ErrorMessage = "The {0} must be at least {2} characters long", MinimumLength = 8)]
        [DataType(DataType.Password)]
        [Display(Name="Password")]
        public string Password { get; set; }
        

        [Required]
        [Display(Name="ConfirmPassword")]
        [Compare("Password", ErrorMessage ="The password and confirm password do not match.")]
        public string ConfirmPassword { get; set; }

    
    }
}