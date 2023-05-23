using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;
using Online_Ticari_Otomasyon.Models.Siniflar;


namespace Online_Ticari_Otomasyon.Controllers
{
    public class UrunController : Controller
    {
        // GET: Urun
        Context c = new Context();
        public ActionResult Index(string p)
        {
            var deger = from x in c.Uruns select x;
            if (!string.IsNullOrEmpty(p))
            {
                deger = deger.Where(y => y.UrunAd.Contains(p));
            }
            return View(deger.ToList());
            
        }
        [HttpGet]
        public ActionResult UrunEkle()
        {
            List<SelectListItem> deger1 = (from x in c.Kategoris.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.KategoriAd,
                                               Value = x.KategoriID.ToString()
                                           }).ToList();
            ViewBag.dgr1 = deger1;
            return View();
        }
        [HttpPost]
        public ActionResult UrunEkle(Urun p)
        {
            c.Uruns.Add(p);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult UrunSil(int id)
        {
            var urun = c.Uruns.Find(id);
            urun.Durum = false;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult UrunGetir(int id)
        {
            List<SelectListItem> deger1 = (from x in c.Kategoris.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.KategoriAd,
                                               Value = x.KategoriID.ToString()
                                           }).ToList();
            ViewBag.dgr1 = deger1;
            var urun = c.Uruns.Find(id);
            return View("UrunGetir", urun);
        }
        public ActionResult UrunGuncelle(Urun p)
        {
            var urun = c.Uruns.Find(p.UrunID);
            urun.UrunAd = p.UrunAd;
            urun.AlısFiyat = p.AlısFiyat;
            urun.SatisFiyat = p.SatisFiyat;
            urun.Durum = p.Durum;
            urun.Kategoriid = p.Kategoriid;
            urun.Marka = p.Marka;
            urun.Stok = p.Stok;
            urun.UrunGorsel = p.UrunGorsel;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Satis(int id)
        {
            List<SelectListItem> deger1 = (from x in c.Personels.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.PersonelAd +" "+x.PersonelSoyad,
                                               Value = x.PersonelID.ToString()
                                           }).ToList();
            ViewBag.dgr1 = deger1;
            List<SelectListItem> deger2 = (from x in c.Carilers.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.CariAd + " " + x.CariSoyad,
                                               Value = x.CariID.ToString()
                                           }).ToList();
            ViewBag.dgr2 = deger2;
            var deger = c.Uruns.Find(id);
            ViewBag.fiyat = deger.SatisFiyat;
            ViewBag.stok = deger.Stok;
            ViewBag.id = id;
            return View();
        }
        [HttpPost]
        public ActionResult Satis(SatisHareket p)
        {
            p.Tarih = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            c.SatisHarekets.Add(p);
            c.SaveChanges();
            return RedirectToAction("Index","Satis");
        
        }
    }
}