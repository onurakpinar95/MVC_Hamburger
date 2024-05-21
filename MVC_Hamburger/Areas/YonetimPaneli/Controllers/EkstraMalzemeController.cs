using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVC_Hamburger.DAL;
using MVC_Hamburger.Models.Concrete;

namespace MVC_Hamburger.Areas.YonetimPaneli.Controllers
{
    [Authorize(Roles = "Yonetici")]
    [Area("YonetimPaneli")]
  
    public class EkstraMalzemeController : Controller
    {
        private readonly HamburgerDbContext _context;
        private readonly SignInManager<Uye> _signInManager;
        private readonly UserManager<Uye> _userManager;

		public EkstraMalzemeController(HamburgerDbContext context, SignInManager<Uye> signInManager, UserManager<Uye> userManager)
		{
			_context = context;
			_signInManager = signInManager;
			_userManager = userManager;
		}


		// GET: YonetimPaneli/EkstraMalzeme
		public async Task<IActionResult> Index()
        {
            var hamburgerDbContext = _context.EkstraMalzemeler.Include(e => e.Kategori);
            return View(await hamburgerDbContext.ToListAsync());
        }

        // GET: YonetimPaneli/EkstraMalzeme/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ekstraMalzeme = await _context.EkstraMalzemeler
                .Include(e => e.Kategori)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (ekstraMalzeme == null)
            {
                return NotFound();
            }

            return View(ekstraMalzeme);
        }

        // GET: YonetimPaneli/EkstraMalzeme/Create
        public IActionResult Create()
        {
            ViewData["KategoriID"] = new SelectList(_context.Kategoriler, "KategoriID", "KategoriAdi");
            return View();
        }

        // POST: YonetimPaneli/EkstraMalzeme/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("KategoriID,ID,Ad,Fiyat")] EkstraMalzeme ekstraMalzeme)
        {

            if (ModelState.IsValid)
            {
                _context.Add(ekstraMalzeme);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["KategoriID"] = new SelectList(_context.Kategoriler, "KategoriID", "KategoriAdi", ekstraMalzeme.KategoriID);
            return View(ekstraMalzeme);
        }

        public async Task<IActionResult> LogOut()
        {
            await _signInManager.SignOutAsync();
			return Redirect("~/Login/Login");
			//return LocalRedirect("~/localhost:5168/Home/Index");
		}


        // GET: YonetimPaneli/EkstraMalzeme/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ekstraMalzeme = await _context.EkstraMalzemeler.FindAsync(id);
            if (ekstraMalzeme == null)
            {
                return NotFound();
            }
            ViewData["KategoriID"] = new SelectList(_context.Kategoriler, "KategoriID", "KategoriAdi", ekstraMalzeme.KategoriID);
            return View(ekstraMalzeme);
        }

        // POST: YonetimPaneli/EkstraMalzeme/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("KategoriID,ID,Ad,Fiyat")] EkstraMalzeme ekstraMalzeme)
        {
            if (id != ekstraMalzeme.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ekstraMalzeme);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EkstraMalzemeExists(ekstraMalzeme.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["KategoriID"] = new SelectList(_context.Kategoriler, "KategoriID", "KategoriAdi", ekstraMalzeme.KategoriID);
            return View(ekstraMalzeme);
        }

        // GET: YonetimPaneli/EkstraMalzeme/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ekstraMalzeme = await _context.EkstraMalzemeler
                .Include(e => e.Kategori)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (ekstraMalzeme == null)
            {
                return NotFound();
            }

            return View(ekstraMalzeme);
        }

        // POST: YonetimPaneli/EkstraMalzeme/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ekstraMalzeme = await _context.EkstraMalzemeler.FindAsync(id);
            if (ekstraMalzeme != null)
            {
                _context.EkstraMalzemeler.Remove(ekstraMalzeme);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EkstraMalzemeExists(int id)
        {
            return _context.EkstraMalzemeler.Any(e => e.ID == id);
        }
    }
}
