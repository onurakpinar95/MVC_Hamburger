using Microsoft.AspNetCore.Mvc.Rendering;

namespace MVC_Hamburger.Models.ViewModels
{
    public class EMKategoriVM
    {
        public int KategoriID { get; set; }
        public string KategoriAdi { get; set; }
        public SelectList EkstraMalzemeler { get; set; }
        public int SecilenEkstraMalzemeID { get; set; }
    }
}
