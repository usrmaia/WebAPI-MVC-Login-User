using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace API.Models.User
{
    public class LoginInput
    {
        [Required(ErrorMessage = "Inform Login")]
        public string Login { get; set; }
        [Required(ErrorMessage = "Inform Password")]
        public string Password { get; set; }
    }
}