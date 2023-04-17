using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TicariOtomasyon.Models.Siniflar;
namespace TicariOtomasyon.Controllers
{
    public class FaturaController : Controller
    {
        // GET: Fatura
        Context c = new Context();
        public ActionResult Index()
        {
            var liste = c.Faturas.ToList();
            return View(liste);
        }
        [HttpGet]
        public ActionResult FaturaEkle()
        {
            List<SelectListItem> deger1 = (from x in c.Tedarikcis.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.TedarikciAd +" "+ x.TedarikciSoyad,
                                               Value = x.TedarikciID.ToString()
                                           }).ToList();
            ViewBag.dgr1 = deger1;
            return View();
        }
        [HttpPost]
        public ActionResult FaturaEkle(Fatura f)
        {
            c.Faturas.Add(f);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult FaturaGetir(int id)
        {
            var ftr = c.Faturas.Find(id);
            return View("FaturaGetir", ftr);
        }
        public ActionResult FaturaGuncelle(Fatura f)
        {
            var ftr = c.Faturas.Find(f.FaturaID);
            ftr.SeriNo = f.SeriNo;
            ftr.SiraNo = f.SiraNo;
            ftr.Tarih = f.Tarih;
            ftr.Saat = f.Saat;
            ftr.VergiDairesi = f.VergiDairesi;
            ftr.PersonelTeslimAlan = f.PersonelTeslimAlan;
            ftr.TedarikciTeslim = f.TedarikciTeslim;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult FaturaDetay(int id)
        {
            var degerler = c.FaturaKalems.Where(x => x.Faturaid == id).ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult YeniKalem()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniKalem(FaturaKalem p)
        {
            c.FaturaKalems.Add(p);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult FaturaSil(int id)
        {
            var ftr = c.Faturas.Find(id);
            c.Faturas.Remove(ftr);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}