using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TicariOtomasyon.Controllers;
using TicariOtomasyon.Models.Siniflar;

namespace TicariOtomasyon.Controllers
{
    
    public class İstatistikController : Controller
    {
        Context c = new Context();
        // GET: İstatistik
        public ActionResult Index()
        {
            var deger1 = c.SatisHarekets.Count().ToString();
            ViewBag.d1 = deger1;
            var deger2 = c.Uruns.Count().ToString();
            ViewBag.d2 = deger2;
            var deger3 = c.Personels.Count().ToString();
            ViewBag.d3 = deger3;
            var deger4 = c.Kategoris.Count().ToString();
            ViewBag.d4 = deger4;
            var deger5 = c.Uruns.Sum(x => x.Stok).ToString();
            ViewBag.d5 = deger5;

            var deger6 = c.Uruns.Count(x => x.Stok <= 15).ToString();
            ViewBag.d6 = deger6;


            var deger7 = (from x in c.Uruns orderby x.SatisFiyat descending select x.UrunAd).FirstOrDefault();
            ViewBag.d7 = deger7;
            var deger8 = (from x in c.Uruns orderby x.SatisFiyat ascending select x.UrunAd).FirstOrDefault();
            ViewBag.d8 = deger8;
            
            var deger9 = (from x in c.SatisHarekets orderby x.Adet descending select x.Urun.UrunAd).FirstOrDefault();
            ViewBag.d9 = deger9;

            var deger10 = c.SatisHarekets.Sum(x => x.Tutar).ToString();
            ViewBag.d10 = deger10;

            DateTime bugun = DateTime.Today;
            var deger11 = c.SatisHarekets.Count(x => x.Tarih == bugun).ToString();
            ViewBag.d11 = deger11;
            var deger12 = c.SatisHarekets.Where(x => x.Tarih == bugun).Sum(y => y.Tutar).ToString();
            ViewBag.d12 = deger12;



            return View();
        }
    }
}