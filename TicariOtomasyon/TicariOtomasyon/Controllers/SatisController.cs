﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TicariOtomasyon.Models.Siniflar;

namespace TicariOtomasyon.Controllers
{
    public class SatisController : Controller
    {
        // GET: Satis
        Context c = new Context();
        public ActionResult Index()
        {
            var degerler = c.SatisHarekets.ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult YeniSatis()
        {
            List<SelectListItem> deger1 = (from x in c.Uruns.ToList() select new SelectListItem { Text = x.UrunAd, Value = x.UrunID.ToString() }).ToList();
            List<SelectListItem> deger2 = (from x in c.Caris.ToList() select new SelectListItem { Text = x.CariAd + " " + x.CariSoyad, Value = x.CariID.ToString() }).ToList();
            List<SelectListItem> deger3 = (from x in c.Personels.ToList() select new SelectListItem { Text = x.PersonelAd + " " + x.PersonelSoyad, Value = x.PersonelID.ToString() }).ToList();
            ViewBag.dgr1 = deger1;
            ViewBag.dgr2 = deger2;
            ViewBag.dgr3 = deger3;
            return View();
        }
        [HttpPost]
        public ActionResult YeniSatis(SatisHareket s)
        {
            s.Tarih = DateTime.Parse(DateTime.Now.ToShortDateString());
            c.SatisHarekets.Add(s);
            c.SaveChanges();
            return RedirectToAction("Index");

        }
        public ActionResult SatisGetir(int id)
        {
            List<SelectListItem> deger1 = (from x in c.Uruns.ToList() select new SelectListItem { Text = x.UrunAd, Value = x.UrunID.ToString() }).ToList();
            List<SelectListItem> deger2 = (from x in c.Caris.ToList() select new SelectListItem { Text = x.CariAd + " " + x.CariSoyad, Value = x.CariID.ToString() }).ToList();
            List<SelectListItem> deger3 = (from x in c.Personels.ToList() select new SelectListItem { Text = x.PersonelAd + " " + x.PersonelSoyad, Value = x.PersonelID.ToString() }).ToList();
            ViewBag.dgr1 = deger1;
            ViewBag.dgr2 = deger2;
            ViewBag.dgr3 = deger3;
            var deger = c.SatisHarekets.Find(id);
            return View("SatisGetir", deger);
        }
        public ActionResult SatisGuncelle(SatisHareket s)
        {
            var deger = c.SatisHarekets.Find(s.SatisHareketID);
            deger.Urunid = s.Urunid;
            deger.Cariid = s.Cariid;
            deger.Personelid = s.Personelid;
            deger.Adet = s.Adet;
            deger.Fiyat = s.Fiyat;
            deger.Tutar = s.Tutar;
            deger.Tarih = s.Tarih;
            c.SaveChanges();
            return RedirectToAction("Index");

        }
        public ActionResult SatisDetay(int id)
        {
            var degerler = c.SatisHarekets.Where(x => x.SatisHareketID == id).ToList();
            return View(degerler);
        }
    }
}