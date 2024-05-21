namespace MVC_Hamburger.Models.Concrete
{
    public class Kategori//Ekstra Malzeme Kategori
    {
        public int KategoriID { get; set; }
        public string KategoriAdi { get; set; }
        public ICollection<EkstraMalzeme>? EkstraMalzemeler { get; set; }
    }
}
