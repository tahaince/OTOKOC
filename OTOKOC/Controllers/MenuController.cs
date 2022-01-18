using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OTOKOC.Models.Entity;
using OTOKOC.Models.classes;

namespace OTOKOC.Controllers
{
    public class MenuController : Controller
    {
        OTOKOCEntities db = new OTOKOCEntities();
        // GET: Menu
        public ActionResult Index(MARKA a , MODEL b)
        {
            var kullanici = (string)Session["Mail"];
            var degerler = db.KULLANICI.FirstOrDefault(x => x.KULLANICIADI == kullanici);
            var ad = degerler.AD;
            var id = degerler.ID;
            var soyad = degerler.SOYAD;
            ViewBag.id = id;


            Class1 cs = new Class1();
            var marka = db.MARKA.Where(x => x.ID == a.ID).FirstOrDefault();
            var model = db.MODEL.Where(x => x.ID == b.ID).FirstOrDefault();


            List<SelectListItem> deger1 = (from i in db.MARKA.ToList()
                                           select new SelectListItem
                                           {
                                               Text = i.AD,
                                               Value = i.ID.ToString()
                                           }
                                   ).ToList();
            ViewBag.dgr1 = deger1;
            

            List<SelectListItem> deger2 = (from i in db.MODEL.ToList()
                                           select new SelectListItem
                                           {
                                               Text = i.MODEL1,
                                               Value = i.ID.ToString()
                                           }
                                 ).ToList();
            ViewBag.dgr2 = deger2;
            cs.deger3 = db.PARCA.ToList();

            return View(cs);
        }

        public ActionResult Ekle(SIPARIS p)
        {

            var kullanici = (string)Session["Mail"];
            var degerler = db.KULLANICI.FirstOrDefault(x => x.KULLANICIADI == kullanici);
            var ad = degerler.AD;
            var id = degerler.ID;
            var soyad = degerler.SOYAD;
           
            p.KULLANICI = id;
            degerler.SIPARIS.Add(p);
            db.SaveChanges();

            return RedirectToAction("Index","Menu");

        }
    }
}