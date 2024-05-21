using MVC_Hamburger.Models.Concrete;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVC_Hamburger.Areas.YonetimPaneli.Models.ViewModels
{
    public class MenuVM
    {
        public MenuEkleVM? MenuEkle { get; set; }
        public Menu? Menu { get; set; }
        public List<Menu>? Menuler { get; set; }
    }
}
