using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LmsOnlineProject.Models;

namespace LmsOnlineProject.Areas.Admin.Controllers
{
    public class KategoriController : Controller
    {
        Context db = new Context();
        public ActionResult KategoriList()
        {
            var values = db.Kategorilers.ToList();
            return View(values);
        }

        public ActionResult KategoriEkle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult KategoriEkle(Kategoriler kategoriler)
        {
            db.Kategorilers.Add(kategoriler);
            db.SaveChanges();
            return RedirectToAction("KategoriList", "Kategori", "Admin");
        }

        public ActionResult KategoriSil(int id) 
        {
            var value = db.Kategorilers.Find(id);
            db.Kategorilers.Remove(value);
            db.SaveChanges();
            return RedirectToAction("KategoriList", "Kategori", "Admin");
        }

        public ActionResult KategoriGetir(int id)
        {
            var value = db.Kategorilers.Find(id);
            return View(value);
        }

        public ActionResult KategoriGuncelle(Kategoriler kategoriler)
        {
            var value = db.Kategorilers.Find(kategoriler.KategoriId);
            value.KategoriAd = kategoriler.KategoriAd;
            db.SaveChanges();
            return RedirectToAction("KategoriList", "Kategori", "Admin");
        }
    }
}