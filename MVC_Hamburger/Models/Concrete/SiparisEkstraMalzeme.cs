namespace MVC_Hamburger.Models.Concrete
{
    public class SiparisEkstraMalzeme
    {
        public int SiparisEkstraMalzemeID { get; set; } 
        public int EkstraMalzemeID { get; set; }  
        public EkstraMalzeme? EkstraMalzeme { get; set; }
        public int SiparisID { get; set; }
        public Siparis? Siparis { get; set; }
        public int EkstraMalzemeAdedi { get; set; }
    }
}
