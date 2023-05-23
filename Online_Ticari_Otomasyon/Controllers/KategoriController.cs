using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Online_Ticari_Otomasyon.Models.Siniflar;
using PagedList;
using PagedList.Mvc;

namespace Online_Ticari_Otomasyon.Controllers
{
    public class KategoriController : Controller
    {
        // GET: Kategori
        Context c = new Context();
        public ActionResult Index(int sayfa=1)
        {
            var Kategoriler = c.Kategoris.ToList().ToPagedList(sayfa, 8);
            return View(Kategoriler);
        }
        [HttpGet]
        public ActionResult KategoriEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult KategoriEkle(Kategori k)
        {
            c.Kategoris.Add(k);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult KategoriSil(int id)
        {
            var ktg = c.Kategoris.Find(id);
            c.Kategoris.Remove(ktg);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult KategoriGetir(int id)
        {
            var ktg= c.Kategoris.Find(id);
            return View("KategoriGetir", ktg);
        }
        public ActionResult KategoriGuncelle(Kategori k)
        {
            var ktg = c.Kategoris.Find(k.KategoriID);
            ktg.KategoriAd = k.KategoriAd;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}