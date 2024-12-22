using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LmsOnlineProject.Models;

namespace LmsOnlineProject.Areas.Admin.Controllers
{
    public class BransController : Controller
    {
        Context db = new Context();
        public ActionResult BransList()
        {
            var bransliste = db.Branslars.ToList();
            return View(bransliste);
        }

        [HttpGet]
        public ActionResult BransEkle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult BransEkle(Branslar branslar)
        {
            db.Branslars.Add(branslar);
            db.SaveChanges();
            return RedirectToAction("BransList", "Brans", "Admin");
        }

        public ActionResult BransSil(int id)
        {
            var value = db.Branslars.Find(id);
            db.Branslars.Remove(value);
            db.SaveChanges();
            return RedirectToAction("BransList", "Brans", "Admin");
        }

        public ActionResult BransGetir(int id) 
        {
            var brans = db.Branslars.Find(id);
            return View(brans);
        }

        [HttpPost]
        public ActionResult BransGuncelle (Branslar branslar)
        {
            var value = db.Branslars.Find(branslar.BransId);
            value.BransAd = branslar.BransAd;
            db.SaveChanges();
            return RedirectToAction("BransList", "Brans", "Admin");
        }
    }
}