using MVC_Hamburger.Models.Concrete;
using MVC_Hamburger.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace MVC_Hamburger.Models.ViewModels
{
    public class SepetDTO
    {
        public int SepetID { get; set; }
        public decimal SiparisFiyati { get; set; }
        [Display(Name ="Toplam Fiyat")]
        public decimal  ToplamFiyat { get; set; }
        public string EkstraMalzemeDetay { get; set; }
        [Display(Name ="Menü Adedi")]
        public int MenuAdedi {  get; set; } 
        public Boy SiparisBoyu { get; set; }
        public Menu SepetMenu { get; set; }
        public int SepetMenuID {  get; set; } 
        public DateTime OlusturulmaTarihi { get; set; } = DateTime.Now;
        public int UyeID { get; set; }  
        public List<int> EkstraMalzemeIdler { get; set; }
    }
}
