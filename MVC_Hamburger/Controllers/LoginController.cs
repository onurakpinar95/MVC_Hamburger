using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MVC_Hamburger.DAL;
using MVC_Hamburger.Models.Concrete;
using MVC_Hamburger.Models.ViewModels;

namespace MVC_Hamburger.Controllers
{
    public class LoginController : Controller
    {
        private readonly SignInManager<Uye> _signInManager;
        private readonly UserManager<Uye> _userManager;
        private readonly HamburgerDbContext _dbContext; 

        public LoginController(SignInManager<Uye> signInManager, UserManager<Uye> userManager, HamburgerDbContext dbContext)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _dbContext = dbContext;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginVM login)
        {
            var uye = await _userManager.FindByEmailAsync(login.Email);

            if (uye == null || !await _userManager.CheckPasswordAsync(uye, login.Sifre))
            {
                ModelState.AddModelError("Hata", "Kullanıcı adı veya şifre yanlış...");
                return View(login);
            }

            await _signInManager.SignInAsync(uye, false);
            return RedirectToAction("Index", "Home");
        }

        //[HttpPost]
        public async Task<IActionResult> LogOut()
        {
            await _signInManager.SignOutAsync();
            return Redirect("~/Login/Login");
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterVM register)
        {
            var usernames= _dbContext.Users.Select(x=>x.Email).ToList();
            if (usernames.Contains(register.Email))
            {
                TempData["Hata"] = " Bu email daha önce kullanılmıştır";
                return RedirectToAction("Register", "Login");
            }
            if(!ModelState.IsValid)
            {
                return View(register);
            }
            Uye uye = new Uye();
            uye.Adres = register.Adres;
            uye.UserName = register.Email;
            uye.Email = register.Email;

            uye.PasswordHash = _userManager.PasswordHasher.HashPassword(uye, register.Sifre);
            var result = await _userManager.CreateAsync(uye);

            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(uye, "Musteri");
                 TempData["Basarili"] = "Kayıt Başarılı";
                return RedirectToAction("Login", "Login");
            }

            return View();
        }
    }
}
