using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;
using Online_Ticari_Otomasyon.Models.Siniflar;

namespace Online_Ticari_Otomasyon.Controllers
{
    public class IstatistikController : Controller
    {
        // GET: Istatistik
        Context c = new Context();
        public ActionResult Index()
        {
            DateTime bugun = DateTime.Today;
            var deger1 = c.Carilers.Count().ToString();
            var deger2 = c.Uruns.Count().ToString();
            var deger3 = c.Personels.Count().ToString();
            var deger4 = c.Kategoris.Count().ToString();
            var deger5 = c.Uruns.Sum(x => x.Stok).ToString();
            var deger6 = (from x in c.Uruns select x.Marka).Distinct().Count().ToString();
            var deger7 = c.Uruns.Where(x => x.Stok <= 20).Count().ToString();
            var deger8 = c.Uruns.OrderByDescending(x => x.SatisFiyat).Select(z => z.UrunAd).FirstOrDefault();
            var deger9 = c.Uruns.OrderBy(x => x.SatisFiyat).Select(z => z.UrunAd).FirstOrDefault();
            var deger10 = c.Uruns.GroupBy(x => x.Marka).OrderByDescending(z => z.Count()).Select(x => x.Key).FirstOrDefault();
            var deger11 = c.Uruns.Where(x => x.UrunAd == "Buzdolabı").Count().ToString();
            var deger12 = c.Uruns.Where(x => x.UrunAd == "Laptop").Count().ToString();
            var deger13 = c.SatisHarekets.GroupBy(x => x.Urun.UrunAd).OrderByDescending(x => x.Count()).Select(x => x.Key).FirstOrDefault();
            var deger14 = c.SatisHarekets.Sum(x => x.ToplamTutar).ToString();
            var deger15 = c.SatisHarekets.Where(x => x.Tarih == bugun).Count().ToString();
            var deger16 = c.Giders.Sum(x => x.Tutar).ToString();


            ViewBag.d1 = deger1;
            ViewBag.d2 = deger2;
            ViewBag.d3 = deger3;
            ViewBag.d4 = deger4;
            ViewBag.d5 = deger5;
            ViewBag.d6 = deger6;
            ViewBag.d7 = deger7;
            ViewBag.d8 = deger8;
            ViewBag.d9 = deger9;
            ViewBag.d10 = deger10;
            ViewBag.d11 = deger11;
            ViewBag.d12 = deger12;
            ViewBag.d13 = deger13;
            ViewBag.d14 = deger14;
            ViewBag.d15 = deger15;
            ViewBag.d16 = deger16;
            
            


            return View();
        }
        public ActionResult BasitTablo()
        {
            var sorgu = from x in c.Carilers
                        group x by x.CariSehir into g
                        select new SinifGrup
                        {
                            Sehir = g.Key,
                            Sayi = g.Count()
                        };
            return View(sorgu.ToList());
        }

        public PartialViewResult Partial1()
        {
            var sorgu = from x in c.Personels
                        group x by x.Departman.DepartmanAd into g
                        select new SinifGrup2
                        {
                            Departman = g.Key,
                            Sayi = g.Count()
                        };
            return PartialView(sorgu.ToList());
        }
        public PartialViewResult Partial2()
        {
            var deger = c.Carilers.ToList();
            return PartialView(deger);
        }
        public PartialViewResult Partial3()
        {
            var deger = c.Uruns.ToList();
            return PartialView(deger);
        }
        public PartialViewResult Partial4()
        {
            var sorgu = from x in c.Uruns
                        group x by x.Marka into g
                        select new SinifGrup3
                        {
                            Marka = g.Key,
                            Sayi = g.Count()
                        };
            return PartialView(sorgu);
        }
    }
}