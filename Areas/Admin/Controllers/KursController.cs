using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LmsOnlineProject.Models;

namespace LmsOnlineProject.Areas.Admin.Controllers
{
    public class KursController : Controller
    {
        Context db = new Context();
        public ActionResult KursList()
        {

            var kurslar = db.Kurslars.ToList();
            var egitmenler = db.Egitmenlers.ToList();
            var kategoriler = db.Kategorilers.ToList();

            var model = new KursViewModel
            {
                egitmenlers = egitmenler,
                kategorilers = kategoriler,
                kurslars = kurslar
            };

            return View(model);
        }

        public ActionResult KursSil(int id)
        {
            var value = db.Kurslars.Find(id);
            db.Kurslars.Remove(value);
            db.SaveChanges();
            return RedirectToAction("KursList", "Kurs", "Admin");
        }

        public ActionResult KursEkle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult KursEkle(Kurslar kurslar)
        {
            db.Kurslars.Add(kurslar);
            db.SaveChanges();
            return RedirectToAction("KursList", "Kurs", "Admin");
        }

        public ActionResult KursGetir(int id)
        {
            var value = db.Kurslars.Find(id);
            return View(value);
        }
    }
}