using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcStok.Models.Entity;

namespace MvcStok.Controllers
{
    public class SatisController : Controller
    {
        MVCDbStokEntities db = new MVCDbStokEntities();
        // GET: Satis
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult YeniSatis()
        {
            //List<SelectListItem> deger = (from x in db.TBLURUNLER.ToList()
            //                              select new SelectListItem
            //                              {
            //                                  Text = x.URUNAD,
            //                                  Value = x.URUNID.ToString()
            //                              }
            //                            ).ToList();
            //ViewBag.dgr = deger;

            return View();
        }

        [HttpPost]
        public ActionResult YeniSatis(TBLSATISLAR p)
        {
            //var urn = db.TBLURUNLER.Where(x => x.URUNID == p.TBLURUNLER.URUNID).FirstOrDefault();
            //p.TBLURUNLER = urn;
            db.TBLSATISLAR.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}