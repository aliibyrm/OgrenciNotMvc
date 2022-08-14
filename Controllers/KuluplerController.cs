using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OgrenciNotMvc.Models.EntityFramework;
namespace OgrenciNotMvc.Controllers
{
    public class KuluplerController : Controller
    {
        // GET: Kulupler
        DbMvcOkulEntities db = new DbMvcOkulEntities();
        public ActionResult Index()
        {
            var kulupler = db.TblKulupler.ToList();
            return View(kulupler);
        }
        [HttpGet]
        public ActionResult YeniKulup()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniKulup(TblKulupler p2)
        {
            db.TblKulupler.Add(p2);
            db.SaveChanges();
            return View();
        }
        public ActionResult Sil(int id)
        {
            var kulup = db.TblKulupler.Find(id);
            db.TblKulupler.Remove(kulup);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult KulupGetir(int id)
        {
            var kulup = db.TblKulupler.Find(id);
            return View("KulupGetir",kulup);
        }
        public ActionResult Guncelle(TblKulupler p)
        {
            var klp = db.TblKulupler.Find(p.KulupID);
            klp.KulupAd = p.KulupAd;
            db.SaveChanges();
            return RedirectToAction("Index", "Kulupler");
        }
    }
}