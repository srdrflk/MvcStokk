using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcStok.Models.Entity;
using PagedList;
using PagedList.Mvc;

namespace MvcStok.Controllers
{
    public class UrunController : Controller
    {

        MVCDbStokEntities db = new MVCDbStokEntities();
        // GET: Urun
        public ActionResult Index(int sayfa=1)
        {
            //var deger = db.TBLURUNLER.ToList();
            var deger = db.TBLURUNLER.ToList().ToPagedList(sayfa,5);
            return View(deger);
        }

        [HttpGet]
        public ActionResult UrunEkle()
        {
            List<SelectListItem> degerler = (from i in db.TBLKATEGORILER.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = i.KATEGORIAD,
                                                 Value = i.KATEGORIID.ToString()
                                             }
                                             ).ToList();

            ViewBag.dgr = degerler;
            return View();
        }

        [HttpPost]
        public ActionResult UrunEkle(TBLURUNLER p3)
        {
            var ktg = db.TBLKATEGORILER.Where(x => x.KATEGORIID == p3.TBLKATEGORILER.KATEGORIID).FirstOrDefault();
            p3.TBLKATEGORILER = ktg;
            db.TBLURUNLER.Add(p3);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Sil(int id)
        {
            var sil = db.TBLURUNLER.Find(id);
            db.TBLURUNLER.Remove(sil);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult UrunGetir(int id)
        {
            var dgr = db.TBLURUNLER.Find(id);

            List<SelectListItem> degerler = (from i in db.TBLKATEGORILER.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = i.KATEGORIAD,
                                                 Value = i.KATEGORIID.ToString()
                                             }
                                             ).ToList();

            ViewBag.dgr = degerler;

            return View(dgr);
        }

        public ActionResult Güncelle(TBLURUNLER p1)
        {
            var dgr = db.TBLURUNLER.Find(p1.URUNID);
            dgr.URUNAD = p1.URUNAD;
            dgr.MARKA = p1.MARKA;
            //dgr.URUNKATEGORI = p1.URUNKATEGORI;
            var ktg = db.TBLKATEGORILER.Where(x => x.KATEGORIID == p1.TBLKATEGORILER.KATEGORIID).FirstOrDefault();
            dgr.URUNKATEGORI = ktg.KATEGORIID;
            dgr.FIYAT = p1.FIYAT;
            dgr.STOK = p1.STOK;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}