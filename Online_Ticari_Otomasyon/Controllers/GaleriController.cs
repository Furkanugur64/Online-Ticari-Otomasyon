using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Online_Ticari_Otomasyon.Models.Siniflar;

namespace Online_Ticari_Otomasyon.Controllers
{
    public class GaleriController : Controller
    {
        // GET: Galeri
        Context c = new Context();
        public ActionResult Index()
        {
            var deger = c.Uruns.ToList();
            return View(deger);
        }
    }
}