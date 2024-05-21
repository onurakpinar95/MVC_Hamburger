using System.ComponentModel.DataAnnotations;

namespace MVC_Hamburger.Models.Abstract
{
    public abstract class Urun
    {
        public int ID { get; set; }
        public string Ad { get; set; }
		[DisplayFormat(DataFormatString = "{0:0.##}", ApplyFormatInEditMode = true)]
		public decimal Fiyat { get; set; }
    }
}
