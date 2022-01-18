using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OTOKOC.Models.Entity;

namespace OTOKOC.Controllers
{
    public class LoginController : Controller
    {
        OTOKOCEntities db = new OTOKOCEntities();
        // GET: Login
        [HttpGet]
        public ActionResult Index()
        {
           


            return View();
        }

        [HttpGet]

        public ActionResult Login()
        {

            return View();
        }


            [HttpPost]

        public  ActionResult Login(KULLANICI p)
        {
              p.MAIL= p.KULLANICIADI;
            var kullanici = db.KULLANICI.Where(x => x.KULLANICIADI == p.KULLANICIADI || x.MAIL == p.MAIL && x.SIFRE == p.SIFRE).FirstOrDefault();

            if(kullanici!=null)
            {
                Session["MAIL"] = kullanici.KULLANICIADI.ToString();

                return RedirectToAction("Index", "Menu");
            }
            else
            {
                return View();
            }
            
        }
    }
}