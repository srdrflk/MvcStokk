using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcStok.Models.Entity;
using PagedList;

namespace MvcStok.Controllers
{
    public class MusteriController : Controller
    {
        MVCDbStokEntities db = new MVCDbStokEntities();

        // GET: Musteri
        public ActionResult Index()
        {
            var deger = db.TBLMUSTERILER.ToList(); 
            //int sayfa = 1 -- Index iöine yazılacak
            //var deger = db.TBLMUSTERILER.ToList().ToPagedList(sayfa, 5);
            return View(deger);
        }

        [HttpGet]
        public ActionResult YeniMusteri()
        {
            return View();
        }

        [HttpPost]
        public ActionResult YeniMusteri(TBLMUSTERILER p2)
        {
            if (!ModelState.IsValid)
            {
                return View("YeniMusteri");
            }
            db.TBLMUSTERILER.Add(p2);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Sil(int id)
        {
            var sil = db.TBLMUSTERILER.Find(id);
            db.TBLMUSTERILER.Remove(sil);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult MusteriGetir(int id)
        {
            var gtr = db.TBLMUSTERILER.Find(id);
            return View(gtr);
        }

        public ActionResult Güncelle(TBLMUSTERILER p1)
        {
            var gnc = db.TBLMUSTERILER.Find(p1.MUSTERIID);
            gnc.MUSTERIAD = p1.MUSTERIAD;
            gnc.MUSTERISOYAD = p1.MUSTERISOYAD;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}