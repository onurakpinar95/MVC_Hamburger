using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MVC_Hamburger.Models.Concrete;

namespace MVC_Hamburger.DAL.EntityConfiguration
{
    public class UyeCFG : IEntityTypeConfiguration<Uye>
    {
        public void Configure(EntityTypeBuilder<Uye> builder)
        {
            Uye uye1 = new Uye
            {
                Id = 1,
                UserName = "deniz@admin.com",
                NormalizedUserName = "DENIZ@ADMIN.COM",
                Email = "deniz@admin.com",
                NormalizedEmail = "DENIZ@ADMIN.COM",
                Adres = "Istanbul",
                EmailConfirmed = false,
                ConcurrencyStamp = Guid.NewGuid().ToString(),
                SecurityStamp = Guid.NewGuid().ToString(),
            };

            Uye uye2 = new Uye
            {
                Id = 2,
                UserName = "cemre@admin.com",
                NormalizedUserName = "CEMRE@ADMIN.COM",
                Email = "cemre@admin.com",
                NormalizedEmail = "CEMRE@ADMIN.COM",
                Adres = "Istanbul",
                EmailConfirmed = false,
                ConcurrencyStamp = Guid.NewGuid().ToString(),
                SecurityStamp = Guid.NewGuid().ToString(),
            };

            Uye uye3 = new Uye
            {
                Id = 3,
                UserName = "onur@admin.com",
                NormalizedUserName = "ONUR@ADMIN.COM",
                Email = "onur@admin.com",
                NormalizedEmail = "ONUR@ADMIN.COM",
                Adres = "Istanbul",
                EmailConfirmed = false,
                ConcurrencyStamp = Guid.NewGuid().ToString(),
                SecurityStamp = Guid.NewGuid().ToString(),
            };

            PasswordHasher<Uye> passwordHasher = new PasswordHasher<Uye>();
            uye1.PasswordHash = passwordHasher.HashPassword(uye1, "Deniz_123");
            uye2.PasswordHash = passwordHasher.HashPassword(uye2, "Cemre_123");
            uye3.PasswordHash = passwordHasher.HashPassword(uye3, "Onur_123");
            builder.HasData(uye1, uye2, uye3);
        }
    }
}   
