using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;
using Online_Ticari_Otomasyon.Models.Siniflar;
using PagedList;
using PagedList.Mvc;

namespace Online_Ticari_Otomasyon.Controllers
{
    public class PersonelController : Controller
    {
        // GET: Personel
        Context c = new Context();
        public ActionResult Index(int sayfa=1)
        {
            var deger = c.Personels.Where(x=>x.Durum==true).ToList().ToPagedList(sayfa,3);
            return View(deger);
        }
        [HttpGet]
        public ActionResult PersonelEkle()
        {
            List<SelectListItem> deger = (from x in c.Departmans.Where(x=>x.Durum==true).ToList()
                         select new SelectListItem
                         {
                             Text = x.DepartmanAd,
                             Value = x.DepartmanID.ToString()
                         }).ToList();
            ViewBag.dgr1 = deger;
            return View();
        }
        [HttpPost]
        public ActionResult PersonelEkle(Personel p)
        {
            if (Request.Files.Count>0)
            {
                string dosyaadi = Path.GetFileName(Request.Files[0].FileName);
                string uzantı = Path.GetExtension(Request.Files[0].FileName);
                string yol = "~/Image/" + dosyaadi + uzantı;
                Request.Files[0].SaveAs(Server.MapPath(yol));
                p.PersonelGorsel = "/Image/" + dosyaadi + uzantı;
            }
            p.Durum = true;
            c.Personels.Add(p);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult PersonelSil(int id)
        {
            var per = c.Personels.Find(id);
            per.Durum = false;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult PersonelGetir(int id)
        {
            List<SelectListItem> deger = (from x in c.Departmans.Where(x => x.Durum == true).ToList()
                                          select new SelectListItem
                                          {
                                              Text = x.DepartmanAd,
                                              Value = x.DepartmanID.ToString()
                                          }).ToList();
            ViewBag.dgr1 = deger;
            var per = c.Personels.Find(id);
            return View("PersonelGetir", per);
        }
        public ActionResult PersonelGuncelle(Personel p)
        {
            if (Request.Files.Count > 0)
            {
                string dosyaadi = Path.GetFileName(Request.Files[0].FileName);
                string uzantı = Path.GetExtension(Request.Files[0].FileName);
                string yol = "~/Image/" + dosyaadi + uzantı;
                Request.Files[0].SaveAs(Server.MapPath(yol));
                p.PersonelGorsel = "/Image/" + dosyaadi + uzantı;
            }
            var per = c.Personels.Find(p.PersonelID);
            per.PersonelAd = p.PersonelAd;
            per.PersonelSoyad = p.PersonelSoyad;
            per.PersonelGorsel = p.PersonelGorsel;
            per.Departmanid = p.Departmanid;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult PersonelListe()
        {
            var sorgu = c.Personels.ToList();
            
            return View(sorgu);
        }
    }
}