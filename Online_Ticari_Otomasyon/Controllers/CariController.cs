using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Online_Ticari_Otomasyon.Models.Siniflar;

namespace Online_Ticari_Otomasyon.Controllers
{
    public class CariController : Controller
    {
        // GET: Cari
        Context c = new Context();
        public ActionResult Index()
        {
            var cariliste = c.Carilers.Where(x=>x.Durum==true).ToList();
            return View(cariliste);
        }
        [HttpGet]
        public ActionResult CariEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CariEkle(Cariler p)
        {
            c.Carilers.Add(p);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult CariSil(int id)
        {
            var cr = c.Carilers.Find(id);
            cr.Durum = false;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult CariGetir(int id)
        {
            var cari = c.Carilers.Find(id);
            return View("CariGetir", cari);
        }
        public ActionResult CariGuncelle(Cariler p)
        {
            if (!ModelState.IsValid)
            {
                return View("CariGetir");
            }
            var cr = c.Carilers.Find(p.CariID);
            cr.CariAd = p.CariAd;
            cr.CariSoyad = p.CariSoyad;
            cr.CariSehir = p.CariSehir;
            cr.CariMail = p.CariMail;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult CariSatis(int id)
        {
            var satıs = c.SatisHarekets.Where(x => x.Cariid == id).ToList();
            var cariad = c.Carilers.Where(X => X.CariID == id).Select(z => z.CariAd + " " + z.CariSoyad).FirstOrDefault();
            ViewBag.cariadı = cariad;
            return View(satıs);
        }
    }
}