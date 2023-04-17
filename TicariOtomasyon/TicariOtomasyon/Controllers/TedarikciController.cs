using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TicariOtomasyon.Models.Siniflar;

namespace TicariOtomasyon.Controllers
{
    public class TedarikciController : Controller
    {
        // GET: Tedarikci
        // GET: Personel
        Context c = new Context();
        public ActionResult Index()
        {
            var degerler = c.Tedarikcis.ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult TedarikciEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult TedarikciEkle(Tedarikci u)
        {
            c.Tedarikcis.Add(u);
            c.SaveChanges();
            return RedirectToAction("Index");

        }
        public ActionResult TedarikciSil(int id)
        {
            var tdr = c.Tedarikcis.Find(id);
            c.Tedarikcis.Remove(tdr);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult TedarikciGetir(int id)
        {

            var tedarikcidgr = c.Tedarikcis.Find(id);
            return View("TedarikciGetir", tedarikcidgr);
        }
        public ActionResult TedarikciGuncelle(Tedarikci t)
        {
            var tdr = c.Tedarikcis.Find(t.TedarikciID);
            tdr.TedarikciAd = t.TedarikciAd;
            tdr.TedarikciSoyad = t.TedarikciSoyad;
            tdr.TedarikciSehir = t.TedarikciMail;
            tdr.TedarikciSehir = t.TedarikciSehir;
            c.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}