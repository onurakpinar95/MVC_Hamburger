using Microsoft.AspNetCore.Mvc;
using MVC_Hamburger.DAL;
using MVC_Hamburger.Models.Concrete;
using MVC_Hamburger.Models.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using MVC_Hamburger.Models.Enums;

namespace MVC_Hamburger.Controllers
{
	public class SiparisController : Controller
	{
        private readonly HamburgerDbContext _context;
        private readonly UserManager<Uye> _userManager;

        public static List<SepetDTO> sepettekiSiparisler=new List<SepetDTO>();
        public SiparisController(HamburgerDbContext context, UserManager<Uye> userManager)
        {
            _context = context;
            
            this._userManager = userManager;

        }
        
        public IActionResult SepeteEkle(int? id)
        {
            SiparisVM model = new SiparisVM();
            model.GelenMenu = _context.Menuler
                .Where(sm => sm.ID == id)
                .Select(sm => new SiparisMenuVM
                {
                    MenuId = sm.ID,
                    MenuAdi = sm.Ad,
                    MenuFiyati = sm.Fiyat,
                    MenuResimYolu = sm.ResimYolu,
                    MenuIcerik = sm.Icerik
                })
                .FirstOrDefault();

            model.GelenMenulerSL = new SelectList(_context.Menuler.Where(x => x.ID == id).ToList(), "ID", "Ad");


            var kategoriler = _context.Kategoriler.Include(c => c.EkstraMalzemeler).ToList();
            foreach (var category in kategoriler)
            {
                if (category.KategoriAdi == "Sos")
                {
                    var categoryViewModel1 = new EMKategoriVM
                    {
                        KategoriID = category.KategoriID,
                        KategoriAdi = $"1.{category.KategoriAdi} Seçimi",
                        EkstraMalzemeler = new SelectList(category.EkstraMalzemeler.Select(em => new { em.ID, AdFiyat = $"{em.Ad} - {em.Fiyat.ToString("0.##")} TL" }), "ID", "AdFiyat")
                    };

                    var categoryViewModel2 = new EMKategoriVM
                    {
                        KategoriID = category.KategoriID,
                        KategoriAdi = $"2.{category.KategoriAdi} Seçimi",
                        EkstraMalzemeler = new SelectList(category.EkstraMalzemeler.Select(em => new { em.ID, AdFiyat = $"{em.Ad} - {em.Fiyat.ToString("0.##")} TL" }), "ID", "AdFiyat")
                    };
                    model.EMKategoriler.Add(categoryViewModel1);
                    model.EMKategoriler.Add(categoryViewModel2);
                }
                else
                {
                    var categoryViewModel = new EMKategoriVM
                    {
                        KategoriID = category.KategoriID,
                        KategoriAdi = category.KategoriAdi,
                        EkstraMalzemeler = new SelectList(category.EkstraMalzemeler.Select(em => new { em.ID, AdFiyat = $"{em.Ad} - {em.Fiyat.ToString("0.##")} TL" }), "ID", "AdFiyat")
                    };

                    model.EMKategoriler.Add(categoryViewModel);
                }

            }

            return View(model);
        }
        [HttpPost]
        public IActionResult SepeteEkle(SiparisVM siparisVm)
        {
            
            SepetDTO sepetDTO = new SepetDTO();
            sepetDTO.UyeID = GetUserID();
            var ekstraMalzemeler = _context.EkstraMalzemeler.Include(x => x.Kategori).ToList();
            List<int> emIdler = siparisVm.SecilenEkstraMalzemeIDler.Select(int.Parse).ToList();
            sepetDTO.EkstraMalzemeIdler = emIdler;  
            string emDetay = "";
            decimal emToplam = 0;
            foreach(var emID in emIdler)
            {                
                foreach(var em in ekstraMalzemeler)
                {
                    if(em.ID==emID)
                    {
                        emDetay += $"Seçilen {em.Kategori.KategoriAdi}:{em.Ad} {em.Fiyat.ToString("0.##")} TL- ";
                        emToplam += em.Fiyat;
                    }                    
                }
            }

            sepetDTO.EkstraMalzemeDetay= emDetay;
            sepetDTO.MenuAdedi = siparisVm.MenuAdedi;

            sepetDTO.SiparisBoyu = siparisVm.SecilenBoy;
            
            sepetDTO.SepetMenu = _context.Menuler.Find(siparisVm.SecilenMenu.ID);
            sepetDTO.SepetMenuID = siparisVm.SecilenMenu.ID;

            sepetDTO.SepetID = siparisVm.SiparisVMID;
            if(sepetDTO.SiparisBoyu==Boy.Buyuk)           
                sepetDTO.SepetMenu.Fiyat += 20;           
            else if (sepetDTO.SiparisBoyu == Boy.Orta)
                sepetDTO.SepetMenu.Fiyat += 10;

            sepetDTO.SiparisFiyati = (sepetDTO.SepetMenu.Fiyat * sepetDTO.MenuAdedi) + emToplam;

            sepettekiSiparisler.Add(sepetDTO);

            return RedirectToAction("SepetListele", "Siparis");
        }
        public IActionResult SepettenSil(int id)
        {
            var sepettekiSiparis = sepettekiSiparisler.Where(x => x.UyeID == GetUserID()).FirstOrDefault(x => x.SepetID == id);
            sepettekiSiparisler.Remove(sepettekiSiparis);
            TempData["SepetSil"] = "Seçili ürün sepetten çıkarılmıştır.";
            return RedirectToAction("SepetListele", "Siparis");
        }

        public IActionResult SepetListele(List<SepetDTO> siparisler)
        {
            siparisler = sepettekiSiparisler.Where(x=>x.UyeID==GetUserID()).ToList();

            decimal toplamFiyat= 0;
            
            foreach (var item in siparisler) 
            { 

                toplamFiyat+=item.SiparisFiyati;
            }
            ViewBag.ToplamFiyat= toplamFiyat.ToString("0.##");
            return View(siparisler);    
        }

        public IActionResult SiparisOnayla()
        {
            if(sepettekiSiparisler.Where(x => x.UyeID == GetUserID()).Count()!=0)
            {
                string siparisIdler = "";
                foreach (var item in sepettekiSiparisler.Where(x => x.UyeID == GetUserID()))
                {
                    Siparis yeniSiparis = new Siparis();
                    yeniSiparis.MenuID = item.SepetMenu.ID;
                    yeniSiparis.MenuAdedi = item.MenuAdedi;
                    yeniSiparis.ToplamFiyat = item.SiparisFiyati;
                    yeniSiparis.UyeID = item.UyeID;
                    yeniSiparis.Boy = item.SiparisBoyu;
                   
                    _context.Siparisler.Add(yeniSiparis);
                    _context.SaveChanges();
                    siparisIdler += $"{yeniSiparis.ID},";
                    foreach (var emID in item.EkstraMalzemeIdler)
                    {
                        SiparisEkstraMalzeme sem = new SiparisEkstraMalzeme();
                        sem.SiparisID = yeniSiparis.ID;
                        sem.EkstraMalzemeID = emID;
                        _context.SiparisEkstraMalzemeler.Add(sem);
                    }

                    _context.SaveChanges();

                }
                TempData["SiparisOnay"] = $"{siparisIdler} numaralı sipariş / siparişler onaylanmıştır.";
                sepettekiSiparisler.RemoveAll(x => x.UyeID == GetUserID());
            }
            else
            {
                TempData["SepetBos"] = "Sepette ürün bulunmamaktadır!";
                return RedirectToAction(nameof(SepetListele));
            }
            return RedirectToAction("Siparislerim", "Siparis");
        }

        public IActionResult SiparisGuncelle (int id)
        {
            SepetDTO sepettekiSiparis = sepettekiSiparisler.Where(x => x.UyeID == GetUserID()).FirstOrDefault(x => x.SepetID == id);

            int menuID = sepettekiSiparis.SepetMenuID;

            sepettekiSiparisler.Remove(sepettekiSiparis);
            return RedirectToAction("SepeteEkle", "Siparis", new { id = menuID });
           
        }

        public IActionResult Siparislerim()
        {
            var uyeSiparisler = _context.Siparisler.Where(x=>x.UyeID==GetUserID()).ToList();
            foreach(var item in uyeSiparisler)
            {
                item.Menu = _context.Menuler.Find(item.MenuID);
                item.SiparisEkstraMalzemeler = _context.SiparisEkstraMalzemeler.Where(x => x.SiparisID == item.ID).ToList();
            }
            return View(uyeSiparisler);
        }

        public int GetUserID()
        {
            return int.Parse(_userManager.GetUserId(User));
        }

        public decimal GetEmFiyatById(int id)
        {
            return _context.EkstraMalzemeler.Find(id).Fiyat;
        }

    }
}
