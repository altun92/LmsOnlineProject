using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LmsOnlineProject.Models;

namespace LmsOnlineProject.Areas.Admin.Controllers
{
    public class EgitmenController : Controller
    {
        Context db = new Context();
        public ActionResult EgitmenList()
        {
            var egitmenler = db.Egitmenlers.ToList(); // Egitmenleri veri tabanından çek
            var branslar = db.Branslars.ToList(); // Bransları veri tabanından çek

            var model = new EgitmenViewModel
            {
                Egitmenler = egitmenler,
                Branslar = branslar
            };

            return View(model);
        }

        public ActionResult EgitmenEkle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult EgitmenEkle(Egitmenler egitmenler, int BransId)
        {
            if (ModelState.IsValid)
            {
                // Branşı eğitmene ata
                var brans = db.Branslars.Find(BransId);
                egitmenler.BransId = brans.BransId;

                // Eğitmeni kaydet
                db.Egitmenlers.Add(egitmenler);
                db.SaveChanges();

                return RedirectToAction("EgitmenList", "Egitmen", "Admin");
            }

            // Hata varsa tekrar listeleme sayfasına dön
            var viewModel = new EgitmenViewModel
            {
                Egitmenler = db.Egitmenlers.ToList(),
                Branslar = db.Branslars.ToList()
            };

            return View("EgitmenList", viewModel);
        }

        public ActionResult EgitmenSil(int id)
        {
            var value = db.Egitmenlers.Find(id);
            db.Egitmenlers.Remove(value);
            db.SaveChanges();
            return RedirectToAction("EgitmenList", "Egitmen", "Admin");
        }

        public ActionResult EgitmenGetir(int id)
        {
            List<SelectListItem> branslist = (from x in db.Branslars.ToList()
                                              select new SelectListItem
                                              {
                                                  Text = x.BransAd,
                                                  Value = x.BransId.ToString(),
                                              }).ToList();
            ViewBag.branslist = branslist;
            var value = db.Egitmenlers.Find(id);
            return View(value);
        }

        public ActionResult EgitmenGuncelle(Egitmenler egitmenler)
        {
            var value = db.Egitmenlers.Find(egitmenler.EgitmenId);
            value.EgitmenAd = egitmenler.EgitmenAd;
            value.EgitmenSoyad = egitmenler.EgitmenSoyad;
            value.EgitmenEmail = egitmenler.EgitmenEmail;
            value.EgitmenImage = egitmenler.EgitmenImage;
            value.BransId = egitmenler.BransId;
            db.SaveChanges();
            return RedirectToAction("EgitmenList", "Egitmen", "Admin");
        }
    }
}