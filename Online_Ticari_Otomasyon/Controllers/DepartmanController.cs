using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Online_Ticari_Otomasyon.Models.Siniflar;

namespace Online_Ticari_Otomasyon.Controllers
{
    public class DepartmanController : Controller
    {
        // GET: Departman
        Context c = new Context();
        public ActionResult Index()
        {
            var deger = c.Departmans.Where(x => x.Durum == true).ToList();
            return View(deger);
        }
        [HttpGet]
        public ActionResult DepartmanEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult DepartmanEkle(Departman p)
        {
            c.Departmans.Add(p);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DepartmanSil(int id)
        {
            var dep = c.Departmans.Find(id);
            dep.Durum = false;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DepartmanGetir(int id)
        {
            var dep = c.Departmans.Find(id);
            return View("DepartmanGetir", dep);
        }
        public ActionResult DepartmanGuncelle(Departman p)
        {
            var dep = c.Departmans.Find(p.DepartmanID);
            dep.DepartmanAd = p.DepartmanAd;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DepartmanDetay(int id)
        {
            var dep = c.Departmans.Where(z => z.DepartmanID == id).Select(x => x.DepartmanAd).FirstOrDefault();
            ViewBag.depad = dep;
            var deger = c.Personels.Where(x => x.Departmanid == id).ToList();
            return View("DepartmanDetay",deger);
        }
        public ActionResult DepartmanSatis(int id)
        {
            var per = c.Personels.Where(z => z.PersonelID == id).Select(x => x.PersonelAd + " " + x.PersonelSoyad).FirstOrDefault();
            ViewBag.dgr1 = per;
            var deger = c.SatisHarekets.Where(x => x.Personelid == id).ToList();
            return View(deger);
        }
    }
}