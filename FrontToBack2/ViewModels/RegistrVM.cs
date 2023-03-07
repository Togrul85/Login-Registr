using Microsoft.Build.Framework;
using System.ComponentModel.DataAnnotations;

namespace FrontToBack2.ViewModels
{
    public class RegistrVM
    {
        //[Required,StringLength(100)]
        public string Fullname { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }

        public string Password { get; set; }
    }
}
