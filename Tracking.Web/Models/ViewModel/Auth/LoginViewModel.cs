using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Tracking.Web.Models.ViewModel.Auth
{
    public class LoginViewModel
    {
        //[Required]
        [Display(Name = "Email Address")]
        public string Email { get; set; }
        
        //[Required]
        [Display(Name = "Password")]
        public string Password { get; set; }
        public string Token { get; set; }
        [Display(Name = "Remember?")]
        public bool RememberMe { get; set; }

        public string ReturnUrl { get; set; }
    }
}
