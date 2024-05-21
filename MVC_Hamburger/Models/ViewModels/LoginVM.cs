using MVC_Hamburger.CustomValidations;
using System.ComponentModel.DataAnnotations;

namespace MVC_Hamburger.Models.ViewModels
{
    public class LoginVM
    {
        public int ID { get; set; }
        public string Email { get; set; }
        public string Sifre { get; set; }
    }
}
