using MVC_Hamburger.CustomValidations;
using System.ComponentModel.DataAnnotations;

namespace MVC_Hamburger.Models.ViewModels
{
    public class RegisterVM
    {
        public int ID { get; set; }
        [EmailAddress(ErrorMessage ="Email formatına uygun olmalıdır! Geçerli bir Email giriniz.")]
        public string Email { get; set; }
        public string Adres { get; set; }
        [Sifre]
        public string Sifre { get; set; }
        [Compare("Sifre",ErrorMessage ="Şifreler aynı olmalıdır.")]
        public string SifreTekrari { get; set; }
    }
}
