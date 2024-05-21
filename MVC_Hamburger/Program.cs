using Microsoft.EntityFrameworkCore;
using MVC_Hamburger.DAL;
using MVC_Hamburger.Models.Concrete;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<HamburgerDbContext>(x => x.UseSqlServer(builder.Configuration.GetConnectionString("ConnStr")));

builder.Services.AddIdentity<Uye, Rol>(x => x.SignIn.RequireConfirmedAccount = false).AddEntityFrameworkStores<HamburgerDbContext>().AddRoles<Rol>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
      name: "areas",
      pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
    );
});

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Login}/{action=Login}/{id?}");


app.Run();
