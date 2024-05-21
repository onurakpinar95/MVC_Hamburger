using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MVC_Hamburger.Models.Concrete;

namespace MVC_Hamburger.DAL.EntityConfiguration
{
    public class SiparisCFG : IEntityTypeConfiguration<Siparis>
    {
        public void Configure(EntityTypeBuilder<Siparis> builder)
        {
            builder.HasKey(x => x.ID);
            builder.Property(x => x.ToplamFiyat).HasColumnType("money");
            builder.Property(x => x.Boy).HasConversion<string>();
            builder.HasOne(x => x.Menu).WithMany(x => x.Siparisler).HasForeignKey(x => x.MenuID);
        }
    }
}
