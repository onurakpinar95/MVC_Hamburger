using MVC_Hamburger.Models.Concrete;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVC_Hamburger.Areas.YonetimPaneli.Models.ViewModels
{
    public class MenuEkleVM
    {
        public string MenuAdi { get; set; }
        [Display(Name ="İçindekiler")]
        public string MenuIcerik { get; set; }
        public decimal MenuFiyat { get; set; }
        public IFormFile MenuResim { get; set; }

    }
}
