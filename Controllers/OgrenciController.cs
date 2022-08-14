using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OgrenciNotMvc.Models.EntityFramework;
namespace OgrenciNotMvc.Controllers
{
    public class OgrenciController : Controller
    {
        // GET: Ogrenci
        DbMvcOkulEntities db = new DbMvcOkulEntities();
        public ActionResult Index()
        {
            var ogrenciler = db.TblOgrenciler.ToList();
            return View(ogrenciler);
        }
        [HttpGet]
        public ActionResult YeniOgrenci()
        {
            //Dropdown List Kullanımı
            //List<SelectListItem> items = new List<SelectListItem>();

            //items.Add(new SelectListItem { Text = "Matematik", Value = "0" });

            //items.Add(new SelectListItem { Text = "Fen Bilgisi", Value = "1" });

            //items.Add(new SelectListItem { Text = "Fizik", Value = "2"});

            //items.Add(new SelectListItem { Text = "Kimya", Value = "3" });

            //items.Add(new SelectListItem { Text = "Edebiyat", Value = "3" });

            //ViewBag.DersAd = items;

            //return View();

            List<SelectListItem> degerler = (from i in db.TblKulupler.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = i.KulupAd,
                                                 Value = i.KulupID.ToString()
                                             }).ToList();
            ViewBag.dgr = degerler;
            return View();
        }
        [HttpPost]
        public ActionResult YeniOgrenci(TblOgrenciler p3)
        {
            var klp = db.TblKulupler.Where(m => m.KulupID == p3.TblKulupler.KulupID).FirstOrDefault();
            p3.TblKulupler = klp;
            db.TblOgrenciler.Add(p3);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Sil(int id)
        {
            var ogrenci = db.TblOgrenciler.Find(id);
            db.TblOgrenciler.Remove(ogrenci);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult OgrenciGetir(int id)
        {
            var ogrenci = db.TblOgrenciler.Find(id);
            return View("OgrenciGetir", ogrenci);
        }
        public ActionResult Guncelle(TblOgrenciler p)
        {
            var ogr = db.TblOgrenciler.Find(p.OgrenciID);
            ogr.OgrAd = p.OgrAd;
            ogr.OgrSoyad = p.OgrSoyad;
            ogr.OgrFotograf = p.OgrFotograf;
            ogr.OgrCinsiyet = p.OgrCinsiyet;
            ogr.OgrKulup = p.OgrKulup;
            db.SaveChanges();
            return RedirectToAction("Index", "Ogrenci");
        }
    }
}