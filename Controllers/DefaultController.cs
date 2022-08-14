using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OgrenciNotMvc.Models.EntityFramework;

namespace OgrenciNotMvc.Controllers
{
    public class DefaultController : Controller
    {
        // GET: Default
        DbMvcOkulEntities db = new DbMvcOkulEntities();
        public ActionResult Index()
        {
            var dersler = db.TblDersler.ToList();
            return View(dersler);
        }
        [HttpGet]
        public ActionResult YeniDers()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniDers(TblDersler p)
        {
            db.TblDersler.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Sil(int id)
        {
            var ders = db.TblDersler.Find(id);
            db.TblDersler.Remove(ders);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DersGetir(int id)
        {
            var ders = db.TblDersler.Find(id);
            return View("DersGetir",ders);
        }
        public ActionResult Guncelle(TblDersler p)
        {
            var drs = db.TblDersler.Find(p.DersID);
            drs.DersAd = p.DersAd;
            db.SaveChanges();
            return RedirectToAction("Index", "Default");
        }
    }
}