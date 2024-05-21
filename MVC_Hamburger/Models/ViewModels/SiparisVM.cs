using Microsoft.AspNetCore.Mvc.Rendering;
using MVC_Hamburger.Models.Concrete;
using MVC_Hamburger.Models.Enums;

namespace MVC_Hamburger.Models.ViewModels
{
	public class SiparisVM
	{
        private static int _currentId = 0;
        public SiparisVM()
        {
            SiparisVMID = ++_currentId; 
        } 
        public int SiparisVMID { get; private set; }
        public decimal? ToplamFiyat { get; set; }
        public int? UyeID { get; set; }
        public Menu? SecilenMenu { get; set; }
        public int MenuAdedi { get; set; }
        public SelectList GelenMenulerSL { get; set; }
        public SiparisMenuVM? GelenMenu { get; set; }
        public Boy SecilenBoy { get; set; }
        public List<EMKategoriVM>? EMKategoriler { get; set; } = new List<EMKategoriVM>();
        public List<string> SecilenEkstraMalzemeIDler { get; set; } = new List<string>();
    }
}
