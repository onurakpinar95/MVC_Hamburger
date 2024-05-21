using MVC_Hamburger.Models.Abstract;
using MVC_Hamburger.Models.Enums;

namespace MVC_Hamburger.Models.Concrete
{
    public class EkstraMalzeme : Urun
    {
        public int KategoriID { get; set; }
        public Kategori? Kategori { get; set; }
        public ICollection<SiparisEkstraMalzeme>? SiparisEkstraMalzemeler { get; set; }
    }
}
