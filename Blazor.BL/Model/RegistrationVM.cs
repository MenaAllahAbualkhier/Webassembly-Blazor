using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blazor.BL.Model
{
    public class RegistrationVM
    {
        [Required(ErrorMessage = "This Failed Is Requird")]
        [EmailAddress(ErrorMessage = "Email is Invalid")]
        public string Email { get; set; } = "";

       
        
        [Required(ErrorMessage = "This Failed Is Requird")]
        public string Password { get; set; } = "";


        [Required(ErrorMessage = "This Failed Is Requird")]
        [Compare("Password", ErrorMessage = "Password Not Match")]
        public string PasswordConfirm { get; set; } = "";
    }
}
