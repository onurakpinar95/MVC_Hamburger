using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MVC_Hamburger.Models.Concrete;

namespace MVC_Hamburger.DAL.EntityConfiguration
{
    public class RolCFG : IEntityTypeConfiguration<Rol>
    {
        public void Configure(EntityTypeBuilder<Rol> builder)
        {
            builder.HasData(
              new Rol { Id = 1, Name = "Yonetici", NormalizedName = "YONETICI", ConcurrencyStamp = Guid.NewGuid().ToString() },
              new Rol { Id = 2, Name = "Musteri", NormalizedName = "MUSTERI", ConcurrencyStamp = Guid.NewGuid().ToString() }
            );
        }
    }
}
