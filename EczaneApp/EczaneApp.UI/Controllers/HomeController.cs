using EczaneApp.BusinnessLayer;
using EczaneApp.EntityLayer;
using EczaneApp.UI.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EczaneApp.UI.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        IlacManager m = new IlacManager();
        public static List<SatisDetay> Detaylar = new List<SatisDetay>();
        public static decimal ToplamTutar = 0;
        public ActionResult Index()
        {
            return View(m.Listele());
        }
        [HttpPost]
        public JsonResult SepeteEkle(int id)
        {
            Ilac ilac = m.Listele().Find(x => x.Id == id);
            
            if (ilac != null)
            {
                if (ilac.Adet == 0) return Json(100, JsonRequestBehavior.AllowGet);
                SatisDetay sorgu = Detaylar.Find(x => x.IlacId == ilac.Id);
                if (sorgu == null)
                {
                    SatisDetay d = new SatisDetay { IlacId = ilac.Id,IlacAd=ilac.Ad, Adet = 1, AdetFiyat = ilac.Fiyat };
                    Detaylar.Add(d);
                }
                else
                {
                    if (sorgu.Adet == ilac.Adet) return Json(100, JsonRequestBehavior.AllowGet);
                    sorgu.Adet++;
                }
                ToplamTutar += ilac.Fiyat;
            }
            int sadet = Detaylar.Sum(x => x.Adet);
            Session["ToplamTutar"] = ToplamTutar;
            Session["SepetAdet"] = sadet;
            return Json(new List<int>() { 1, sadet, Convert.ToInt32(ToplamTutar)}, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult SepetTemizle()
        {          
            if (Detaylar.Count > 0) Detaylar.Clear();
            else return Json(100, JsonRequestBehavior.AllowGet);
            ToplamTutar =0;

            if(Session["ToplamTutar"] != null)
                Session.Remove("ToplamTutar");
            if (Session["SepetAdet"] != null)
                Session.Remove("SepetAdet");
            return Json(1, JsonRequestBehavior.AllowGet);
        }
        public JsonResult SepetOnayla()
        {
            if(Session["user"] == null) return Json(200, JsonRequestBehavior.AllowGet);

            Kullanici k = Session["user"] as Kullanici;
            if (Detaylar.Count > 0)
            {
                using (MusteriManager musterimanager = new MusteriManager())
                {
                    Musteri musteri = musterimanager.Listele().Find(x=> x.Ad == k.Personel.Ad);
                    if(musteri == null) return Json(300, JsonRequestBehavior.AllowGet);
                    Satis satis = new Satis { PersonelId = k.PersonelId, Tarih = DateTime.Now, Tutar = ToplamTutar, MusteriId= musteri.Id };
                    satis.SatisDetaylar = Detaylar;
                    using (SatisManager satisManager = new SatisManager())
                        satisManager.Ekle(satis);
                    Detaylar.Clear();
                }
            }
            else return Json(100, JsonRequestBehavior.AllowGet);
            ToplamTutar = 0;

            if (Session["ToplamTutar"] != null)
                Session.Remove("ToplamTutar");
            if (Session["SepetAdet"] != null)
                Session.Remove("SepetAdet");
            return Json(1, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult SepetGetir()
        {
            if (Detaylar.Count > 0) return Json(Detaylar, JsonRequestBehavior.AllowGet);
            else return Json(100, JsonRequestBehavior.AllowGet);
        }
        
        [HttpPost]
        public JsonResult SepetUrunSil(int index)
        {
            if (Detaylar[index] != null)
            {
                ToplamTutar -= Detaylar[index].AdetFiyat;
                Detaylar[index].Adet--;
                if(Detaylar[index].Adet ==0)
                {
                    Session.Remove("ToplamTutar");
                    Session.Remove("SepetAdet");
                    ToplamTutar = 0;
                    Detaylar.RemoveAt(index);
                }
            }
            else return Json(100, JsonRequestBehavior.AllowGet);

            int sadet = Detaylar.Sum(x => x.Adet);
            if (sadet > 0)
            {
                Session["ToplamTutar"] = ToplamTutar;
                Session["SepetAdet"] = sadet;
            }
            return Json(new List<int>() { 1, sadet, Convert.ToInt32(ToplamTutar) }, JsonRequestBehavior.AllowGet);
        }
    }
}