using EczaneApp.BusinnessLayer;
using EczaneApp.EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace EczaneApp.UI.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        KullaniciManager m = new KullaniciManager();
        public ActionResult Giris()
        {
            return View();
        }
        [HttpPost,ValidateAntiForgeryToken]
        public ActionResult Giris(Kullanici k,string returnUrl = "")
        {
            if(Session["user"] != null) return RedirectToAction("Index", "Home");
            if (m.GirisYap(k.Ad,k.Sifre))
            {
                k = m.kullaniciGetir(k.Ad);
                Session["user"] = k;
                if(String.IsNullOrWhiteSpace(returnUrl))
                    return RedirectToAction("Index","Home");
                else Response.Redirect(returnUrl);
            }
            ModelState.AddModelError("","Kullanıcı adı veya parola hatalı!");
            return View(k);
        }
        public ActionResult Kayit()
        {
            return View();
        }
        [HttpPost,ValidateAntiForgeryToken]
        public ActionResult Kayit(Kullanici k)
        {
            if (ModelState.IsValid)
            {
                m.Ekle(k);
                using (MusteriManager musteriManager = new MusteriManager())
                    musteriManager.Ekle(new Musteri { Ad = k.Personel.Ad, Soyad = k.Personel.Soyad, TC = k.Personel.TC, DogumTarih=k.Personel.DogumTarih }) ;
                return RedirectToAction("Giris", "User", new { area = "" });
            }
            return View();
        }
        public ActionResult Cikis()
        {
            if (Session["user"] != null) Session.Remove("user");
            return RedirectToAction("Index", "Home");
        }
    }
}