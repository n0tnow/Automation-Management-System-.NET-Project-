using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TicariOtomasyon.Models.Siniflar;

namespace TicariOtomasyon.Controllers
{
    public class PersonelController : Controller
    {
        // GET: Personel
        Context c = new Context();
        public ActionResult Index()
        {
            var degerler = c.Personels.ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult PersonelEkle()
        {
            List<SelectListItem> deger2 = (from x in c.Departmen.ToList() select new SelectListItem { Text = x.DepartmanAd, Value = x.DepartmanID.ToString() }).ToList();
            ViewBag.dgr2 = deger2;
            return View();
        }
        [HttpPost]
        public ActionResult PersonelEkle(Personel p)
        {
            c.Personels.Add(p);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult PersonelGetir(int id)
        {
            List<SelectListItem> deger3 = (from x in c.Departmen.ToList() select new SelectListItem { Text = x.DepartmanAd, Value = x.DepartmanID.ToString() }).ToList();
            ViewBag.dgr3 = deger3;
            var pers = c.Personels.Find(id);
            return View("PersonelGetir", pers);
        }
        public ActionResult PersonelGuncelle(Personel p)
        {
            var prsn = c.Personels.Find(p.PersonelID);
            prsn.PersonelAd = p.PersonelAd;
            prsn.PersonelSoyad = p.PersonelSoyad;
            prsn.PersonelGorsel = p.PersonelGorsel;
            prsn.Departmanid = p.Departmanid;
            c.SaveChanges();
            return RedirectToAction("PersonelDetayListesi");
            
        }
        public ActionResult PersonelListesi()
        {
            var degerler = c.Personels.ToList();
            return View(degerler);
        }

        public ActionResult PersonelDetayListesi()
        {
            var sorgu = c.Personels.ToList();
            return View(sorgu);
        }


    }
}