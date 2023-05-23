using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Online_Ticari_Otomasyon.Models.Siniflar;

namespace Online_Ticari_Otomasyon.Controllers
{
    public class FaturalarController : Controller
    {
        // GET: Fatura
        Context c = new Context();
        public ActionResult Index()
        {
            var deger = c.Faturalars.ToList();
            return View(deger);
        }
        [HttpGet]
        public ActionResult YeniFatura()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniFatura(Faturalar p)
        {
            c.Faturalars.Add(p);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult FaturaGetir(int id)
        {
            var fat = c.Faturalars.Find(id);
            return View("FaturaGetir", fat);
        }
        public ActionResult FaturaGuncelle(Faturalar f)
        {
            var fat = c.Faturalars.Find(f.FaturaID);
            fat.FaturaSeriNo = f.FaturaSeriNo;
            fat.FaturaSıraNo = f.FaturaSıraNo;
            fat.Tarih = f.Tarih;
            fat.TeslimAlan = f.TeslimAlan;
            fat.TeslimEden = f.TeslimEden;
            fat.VergiDairesi = f.VergiDairesi;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult FaturaDetay(int id)
        {
            var detay = c.FaturaKalems.Where(x => x.Faturaid == id).ToList();
            return View(detay);
        }
        [HttpGet]
        public ActionResult YeniKalem()
        {
            
            return View();
        }
        [HttpPost]
        public ActionResult YeniKalem(FaturaKalem p)
        {         
            c.FaturaKalems.Add(p);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}