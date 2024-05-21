using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MVC_Hamburger.Models.Concrete;

namespace MVC_Hamburger.DAL.EntityConfiguration
{
    public class EkstraMalzemeCFG : IEntityTypeConfiguration<EkstraMalzeme>
    {
        public void Configure(EntityTypeBuilder<EkstraMalzeme> builder)
        {
            builder.HasKey(x => x.ID);
            builder.Property(x => x.Ad).HasColumnType("varchar").HasMaxLength(50);
            builder.Property(x => x.Fiyat).HasColumnType("money");
            builder.HasOne(x => x.Kategori).WithMany(x => x.EkstraMalzemeler).HasForeignKey(x => x.KategoriID);
            builder.HasData(
                new EkstraMalzeme() { ID = 1, Ad = "Sos İstemiyorum", Fiyat = 0, KategoriID = 3 },
                new EkstraMalzeme() { ID = 2, Ad = "Ketçap", Fiyat = 10, KategoriID = 3 },
                new EkstraMalzeme() { ID = 3, Ad = "Mayonez", Fiyat = 10, KategoriID = 3 },
                new EkstraMalzeme() { ID = 4, Ad = "Hardal", Fiyat = 10, KategoriID = 3 },
                new EkstraMalzeme() { ID = 5, Ad = "Barbekü", Fiyat =10, KategoriID = 3 },
                new EkstraMalzeme() { ID = 6, Ad = "Coca Cola", Fiyat = 0, KategoriID = 1 },
                new EkstraMalzeme() { ID = 7, Ad = "Fanta", Fiyat = 0, KategoriID = 1 },
                new EkstraMalzeme() { ID = 8, Ad = "Sprite", Fiyat = 0, KategoriID = 1 },
                new EkstraMalzeme() { ID = 9, Ad = "Ice Tea", Fiyat = 0, KategoriID = 1 },
                new EkstraMalzeme() { ID = 10, Ad = "Ayran", Fiyat = 0, KategoriID = 1 },
                new EkstraMalzeme() { ID = 11, Ad = "Su", Fiyat = 0, KategoriID = 1 },
                new EkstraMalzeme() { ID = 12, Ad = "Soda", Fiyat = 0, KategoriID = 1 },
                new EkstraMalzeme() { ID = 13, Ad = "Limonata", Fiyat = 0, KategoriID = 1 },
                new EkstraMalzeme() { ID = 14, Ad = "Ekstra Çıtır Lezzet Istemiyorum", Fiyat = 0, KategoriID = 4 },
                new EkstraMalzeme() { ID = 15, Ad = "Soğan Halkası 6'lı", Fiyat = 30, KategoriID = 4 },
                new EkstraMalzeme() { ID = 16, Ad = "Soğan Halkası 12'li", Fiyat = 50, KategoriID = 4 },
                new EkstraMalzeme() { ID = 17, Ad = "Nugget 6'lı", Fiyat = 40, KategoriID = 4 },
                new EkstraMalzeme() { ID = 18, Ad = "Nugget 12'li", Fiyat = 60, KategoriID = 4 },
                new EkstraMalzeme() { ID = 19, Ad = "Ekstra Tatlı Istemiyorum", Fiyat = 0, KategoriID = 2 },
                new EkstraMalzeme() { ID = 20, Ad = "Sufle", Fiyat = 40, KategoriID = 2 },
                new EkstraMalzeme() { ID = 21, Ad = "Donut", Fiyat = 30, KategoriID = 2 },
                new EkstraMalzeme() { ID = 22, Ad = "Dondurma", Fiyat = 20, KategoriID = 2 }
                );                                                              
        }
    }
}
