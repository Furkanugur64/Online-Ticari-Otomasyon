using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.Mvc;
using Online_Ticari_Otomasyon.Models.Siniflar;

namespace Online_Ticari_Otomasyon.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        Context c = new Context();
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public PartialViewResult MusteriEkle()
        {
            return PartialView();
        }
        [HttpPost]
        public PartialViewResult MusteriEkle(Cariler p)
        {
            c.Carilers.Add(p);
            c.SaveChanges();
            return PartialView();
        }
        [HttpGet]
        public ActionResult MusteriGiris()
        {
            return View();
        }
        [HttpPost]
        public ActionResult MusteriGiris(Cariler p)
        {
            var bilgiler = c.Carilers.FirstOrDefault(x => x.CariMail == p.CariMail && x.CariSifre == p.CariSifre);
            if (bilgiler!=null)
            {
                FormsAuthentication.SetAuthCookie(bilgiler.CariMail, false);
                Session["CariMail"] = bilgiler.CariMail.ToString();
                return RedirectToAction("Index", "CariPanel");
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
           
        }

        [HttpGet]
        public ActionResult AdminGiris()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AdminGiris(Admin p)
        {
            var bilgiler = c.Admins.FirstOrDefault(x => x.KullaniciAd == p.KullaniciAd && x.Sifre == p.Sifre);
            if (bilgiler != null)
            {
                FormsAuthentication.SetAuthCookie(bilgiler.KullaniciAd, false);
                Session["KullaniciAd"] = bilgiler.KullaniciAd.ToString();
                return RedirectToAction("Index", "Urun");
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }

        }
    }
}