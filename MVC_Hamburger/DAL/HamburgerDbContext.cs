using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MVC_Hamburger.Models.Concrete;
using System.Reflection;
using MVC_Hamburger.Models.ViewModels;
using MVC_Hamburger.Areas.YonetimPaneli.Models.ViewModels;

namespace MVC_Hamburger.DAL
{
    public class HamburgerDbContext : IdentityDbContext<Uye, Rol, int>
    {
        public HamburgerDbContext()
        {

        }

        public HamburgerDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<EkstraMalzeme> EkstraMalzemeler { get; set; }
        public DbSet<Kategori> Kategoriler { get; set; }//Ekstra malzemenin kategorisi
        public DbSet<Menu> Menuler { get; set; }
        public DbSet<Siparis> Siparisler { get; set; }
        public DbSet<SiparisEkstraMalzeme> SiparisEkstraMalzemeler { get; set; }
        

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            builder.Entity<IdentityUserRole<int>>().HasData(
                new IdentityUserRole<int>() { UserId = 1, RoleId = 1 },
                new IdentityUserRole<int>() { UserId = 2, RoleId = 1 }, 
                new IdentityUserRole<int>() { UserId = 3, RoleId = 1 });
        }

    }
}
