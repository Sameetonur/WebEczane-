using EczaneApp.BusinnessLayer;
using EczaneApp.EntityLayer;
using EczaneApp.UI.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EczaneApp.UI.Areas.Admin.Controllers
{
    [KimlikKontrol, YetkiKontrol(Yetki = Yetkiler.Admin)]
    public class KullaniciController : Controller
    {
        // GET: Admin/Kullanici
        KullaniciManager m = new KullaniciManager();
        public ActionResult Listele()
        {
            return View(m.Listele());
        }
        public ActionResult Ekle()
        {
            using (PersonelManager pm = new PersonelManager())
                ViewBag.Personeller = new SelectList(pm.Listele(),"Id","Ad");
            return View();
        }
        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Ekle(Kullanici k)
        {
            if (ModelState.IsValid)
            {
                m.Ekle(k);
                return RedirectToAction("Listele");
            }
            using (PersonelManager pm = new PersonelManager())
                ViewBag.Personeller = new SelectList(pm.Listele(), "Id", "Ad");
            return View();
        }
        public ActionResult Duzenle(int id)
        {
            Kullanici k = m.Listele().Find(x => x.Id == id);
            if (k == null)
                HttpNotFound();
            using (PersonelManager pm = new PersonelManager())
                ViewBag.Personeller = new SelectList(pm.Listele(), "Id", "Ad");
            return View(k);
        }
        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Duzenle(Kullanici k)
        {
            if (ModelState.IsValid)
            {
                m.Guncelle(k);
                return RedirectToAction("Listele");
            }
            using (PersonelManager pm = new PersonelManager())
                ViewBag.Personeller = new SelectList(pm.Listele(), "Id", "Ad");
            return View();
        }
        public ActionResult Sil(int id)
        {
            Kullanici k = m.Listele().Find(x => x.Id == id);
            if (k == null)
                HttpNotFound();
            return View(k);
        }
        [HttpPost, ValidateAntiForgeryToken, ActionName("Sil")]
        public ActionResult SilOnay(int id)
        {
            Kullanici k = m.Listele().Find(x => x.Id == id);
            if (k == null)
                HttpNotFound();
            m.Sil(k);
            return RedirectToAction("Listele");
        }
    }
}