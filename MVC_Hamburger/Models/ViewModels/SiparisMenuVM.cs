using MVC_Hamburger.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace MVC_Hamburger.Models.ViewModels
{
	public class SiparisMenuVM
	{
		public int? MenuId { get; set; }
		public string? MenuAdi { get; set; }
        [DisplayFormat(DataFormatString = "{0:0.##}", ApplyFormatInEditMode = true)]
        public decimal MenuFiyati { get; set; }
		public int? MenuAdedi { get; set; }
		public string? MenuIcerik{ get; set; }
        public string? MenuResimYolu { get; set; }
	}
}
