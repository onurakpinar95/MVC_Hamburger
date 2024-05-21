using MVC_Hamburger.Models.Enums;

namespace MVC_Hamburger.Models.Concrete
{
    public class Siparis
    {
        public int ID { get; set; }
        public decimal ToplamFiyat { get; set; }
        public DateTime OlusturulmaTarihi { get; set; } = DateTime.Now;
        public Boy Boy { get; set; }
        public int UyeID { get; set; }
        public Uye Uye { get; set; }
        public int MenuID { get; set; }
        public int MenuAdedi { get; set; }    
        public Menu? Menu{ get; set; }
        public ICollection<SiparisEkstraMalzeme>? SiparisEkstraMalzemeler { get; set; }
    }
}
