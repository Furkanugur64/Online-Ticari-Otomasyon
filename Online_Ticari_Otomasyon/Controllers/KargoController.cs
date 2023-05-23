using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Online_Ticari_Otomasyon.Models.Siniflar;
using QRCoder;

namespace Online_Ticari_Otomasyon.Controllers
{
    public class KargoController : Controller
    {
        // GET: Kargo
        Context c = new Context();
        public ActionResult Index(string p)
        {
            var deger = from x in c.KargoDetays select x;
            if (!string.IsNullOrEmpty(p))
            {
                deger = deger.Where(y => y.TakipKodu.Contains(p));
            }
            return View(deger.ToList());
        }
        [HttpGet]
        public ActionResult YeniKargo()
        {
            Random rnd = new Random();
            string[] harf = { "A", "B", "C", "D", "E", "F", "H", "G", "K" };
            int k1, k2, k3;
            k1 = rnd.Next(0, harf.Length);
            k2 = rnd.Next(0, harf.Length);
            k3 = rnd.Next(0, harf.Length);
            int s1, s2, s3;
            s1 = rnd.Next(100, 1000);
            s2 = rnd.Next(10, 99);
            s3 = rnd.Next(10, 99);
            string kod = s1.ToString() + harf[k1] + s2 + harf[k2] + s3 + harf[k3];
            ViewBag.takip = kod;
            return View();
        }
        [HttpPost]
        public ActionResult YeniKargo(KargoDetay p)
        {
            p.Tarih = DateTime.Today;
            c.KargoDetays.Add(p);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Detay(string id)
        {
            var cari = c.KargoDetays.Where(x => x.TakipKodu == id).Select(c => c.Alici).FirstOrDefault();
            ViewBag.d1 = cari;
            var kargo = c.KargoTakips.Where(x => x.TakipKodu == id).ToList();
            return View(kargo);
        }
        public ActionResult QR()
        {
            return View();
        }
        [HttpPost]
        public ActionResult QR(string kod)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                QRCodeGenerator koduret = new QRCodeGenerator();
                QRCodeGenerator.QRCode karekod = koduret.CreateQrCode(kod, QRCodeGenerator.ECCLevel.Q);
                using (Bitmap resim = karekod.GetGraphic(10))
                {
                    resim.Save(ms, ImageFormat.Png);
                    ViewBag.karekod = "data:image/png;base64," + Convert.ToBase64String(ms.ToArray());
                }
            }
            return View();
        }
    }
}