using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;
using Online_Ticari_Otomasyon.Models.Siniflar;

namespace Online_Ticari_Otomasyon.Controllers
{
    public class SatisController : Controller
    {
        // GET: Satis
        Context c = new Context();
        public ActionResult Index()
        {
            var degerler = c.SatisHarekets.ToList();
            return View(degerler);
        }
       
        
        public ActionResult SatisGetir(int id)
        {
            List<SelectListItem> deger1 = (from x in c.Uruns.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.UrunAd,
                                               Value = x.UrunID.ToString()
                                           }).ToList();
            List<SelectListItem> deger2 = (from x in c.Carilers.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.CariAd + " " + x.CariSoyad,
                                               Value = x.CariID.ToString()
                                           }).ToList();
            List<SelectListItem> deger3 = (from x in c.Personels.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.PersonelAd + " " + x.PersonelSoyad,
                                               Value = x.PersonelID.ToString()
                                           }).ToList();
            ViewBag.dgr1 = deger1;
            ViewBag.dgr2 = deger2;
            ViewBag.dgr3 = deger3;
            var satis = c.SatisHarekets.Find(id);
            return View("SatisGetir", satis);
        }
        public ActionResult SatisGuncelle(SatisHareket p)
        {
            var sat = c.SatisHarekets.Find(p.SatisID);
            sat.Urunid = p.Urunid;
            sat.Personelid = p.Personelid;
            sat.Cariid = p.Cariid;
            sat.Adet = p.Adet;
            sat.Fiyat = p.Fiyat;
            sat.ToplamTutar = p.ToplamTutar;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult SatisDetay(int id)
        {
            var deger = c.SatisHarekets.Where(x=>x.SatisID==id).ToList();
            return View(deger);
        }
    }
}