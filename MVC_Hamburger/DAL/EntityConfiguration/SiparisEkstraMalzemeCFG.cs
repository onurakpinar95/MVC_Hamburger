using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MVC_Hamburger.Models.Concrete;

namespace MVC_Hamburger.DAL.EntityConfiguration
{
    public class SiparisEkstraMalzemeCFG : IEntityTypeConfiguration<SiparisEkstraMalzeme>
    {
        public void Configure(EntityTypeBuilder<SiparisEkstraMalzeme> builder)
        {
            builder.HasKey(x => x.SiparisEkstraMalzemeID);
            builder.HasOne(x => x.Siparis).WithMany(x => x.SiparisEkstraMalzemeler);
            builder.HasOne(x => x.EkstraMalzeme).WithMany(x => x.SiparisEkstraMalzemeler);
        }
    }
}
