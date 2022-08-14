using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OgrenciNotMvc.Models.EntityFramework;
using OgrenciNotMvc.Models;
namespace OgrenciNotMvc.Controllers

{
    public class NotlarController : Controller
    {
        // GET: Notlar
        DbMvcOkulEntities db = new DbMvcOkulEntities();
        public ActionResult Index()
        {
            var SinavNotlar = db.TblNotlar.ToList();
            return View(SinavNotlar);
        }
        [HttpGet]
        public ActionResult YeniSinav()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniSinav(TblNotlar tbn)
        {
            db.TblNotlar.Add(tbn);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult NotGetir(int id)
        {
            var notlar = db.TblNotlar.Find(id);
            return View("NotGetir", notlar);
        }
        [HttpPost]
        public ActionResult NotGetir(Class1 model, TblNotlar p , int Sınav1=0, int Sınav2=0,int Sınav3=0, int Proje=0 )
        {
            if(model.islem=="Hesapla")
            {
                //işlem1
                int Ortalama = (Sınav1 + Sınav2 + Sınav3 + Proje) / 4;
                ViewBag.ort = Ortalama;
            }
            if(model.islem=="NotGuncelle")
            {
                var snv = db.TblNotlar.Find(p.NotID);
                snv.Sınav1 = p.Sınav1;
                snv.Sınav2 = p.Sınav2;
                snv.Sınav3 = p.Sınav3;
                snv.Proje = p.Proje;
                snv.Ortalama = p.Ortalama;
                db.SaveChanges();
                return RedirectToAction("Index", "Notlar");
            }
            return View();
        }
    }
}