using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MVC_Hamburger.Models.Concrete;

namespace MVC_Hamburger.DAL.EntityConfiguration
{
    public class KategoriCFG : IEntityTypeConfiguration<Kategori>
    {
        public void Configure(EntityTypeBuilder<Kategori> builder)
        {
            builder.HasKey(x=>x.KategoriID);
            builder.Property(x => x.KategoriAdi);
           
            builder.HasData(
                
                new Kategori() { KategoriID=1, KategoriAdi="İçecek"},
                new Kategori() { KategoriID=2, KategoriAdi="Tatlı"},
                new Kategori() { KategoriID=3, KategoriAdi= "Sos" },
                new Kategori() { KategoriID = 4, KategoriAdi = "Çıtır Lezzetler" }
                );
        }
    }
}
