using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MVC_Hamburger.Models.Concrete;
using MVC_Hamburger.Models.Enums;

namespace MVC_Hamburger.DAL.EntityConfiguration
{
    public class MenuCFG : IEntityTypeConfiguration<Menu>
    {
        public void Configure(EntityTypeBuilder<Menu> builder)
        {
            builder.HasKey(x => x.ID);
            builder.Property(x => x.Ad).HasColumnType("varchar").HasMaxLength(150);
            builder.Property(x => x.ResimYolu).HasColumnType("varchar").HasMaxLength(100);
            builder.Property(x => x.Icerik).HasColumnType("varchar").HasMaxLength(250);
           
            builder.Property(x => x.Fiyat).HasColumnType("money");
            builder.HasData(
                new Menu { ID=1, Ad= "Etli Barbeku Menü", Icerik= "Etli Barbekü Burger, Patates Kızartması (Küçük),Kutu İçecek", Fiyat=200, ResimYolu= "1_etlibarbeku_menu.png" },
                new Menu { ID=2, Ad= "Big Burger Menü", Icerik= "Big Burger, Patates Kızartması (Küçük), Kutu İçecek", Fiyat=250, ResimYolu= "2_ozelbig_menu.png" },
                new Menu { ID=3, Ad= "Süper Chicken Menü", Icerik= "Süper Chicken Burger, Patates Kızartması (Küçük),Kutu İçecek, Soğan Halkası 6'lı", Fiyat=230, ResimYolu= "8_superchicken_menu.png" },
                new Menu { ID=4, Ad= "İkili Burger Menü", Icerik= "Big Burger, Süper Chicken Burger,Patates Kızartması (Küçük), 1 L. İçecek", Fiyat=380, ResimYolu= "5_ikiliburger.png" },
                new Menu { ID=5, Ad= "Üçlü Whopper Burger Menü", Icerik= "3X Whopper Burger,Patates Kızartması (Küçük), 1 L. İçecek", Fiyat=600, ResimYolu= "3_3luwhopper.png" },
                new Menu { ID=6, Ad= "Üçlü Burger Menü", Icerik= "3X Süper Chicken Burger, Patates Kızartması (Küçük), 1 L. İçecek", Fiyat=550, ResimYolu= "7_benimuclum.png" }
                );
        }
    }
}
