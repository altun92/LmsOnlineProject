using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LmsOnlineProject.Models;

namespace LmsOnlineProject.Areas.Admin.Controllers
{
    public class DashboardController : Controller
    {
        Context db = new Context();
        public ActionResult Index()
        {
            ViewBag.egitmenSayisi = db.Egitmenlers.Count();

            ViewBag.ogrenciSayisi = db.Ogrencilers.Count();

            ViewBag.kursSayisi = db.Kurslars.Count();
            return View();
        }
    }
}