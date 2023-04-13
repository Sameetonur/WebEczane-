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
    [KimlikKontrol,YetkiKontrol(Yetki =Yetkiler.Admin)]
    public class IlacController : Controller
    {
        // GET: Admin/Ilac
        IlacManager m = new IlacManager();
        public ActionResult Listele()
        {
            return View(m.Listele());
        }
        public ActionResult Ekle()
        {
            using (KategoriManager pm = new KategoriManager())
                ViewBag.Kategoriler = new SelectList(pm.Listele(), "Id", "Ad");
            return View();
        }
        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Ekle(Ilac k)
        {
            if (ModelState.IsValid)
            {
                m.Ekle(k);
                return RedirectToAction("Listele");
            }
            using (KategoriManager pm = new KategoriManager())
                ViewBag.Kategoriler = new SelectList(pm.Listele(), "Id", "Ad");
            return View();
        }
        public ActionResult Duzenle(int id)
        {
            Ilac k = m.Listele().Find(x => x.Id == id);
            if (k == null)
                HttpNotFound();
            using (KategoriManager pm = new KategoriManager())
                ViewBag.Kategoriler = new SelectList(pm.Listele(), "Id", "Ad");
            return View(k);
        }
        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Duzenle(Ilac k)
        {
            if (ModelState.IsValid)
            {
                m.Guncelle(k);
                return RedirectToAction("Listele");
            }
            using (KategoriManager pm = new KategoriManager())
                ViewBag.Kategoriler = new SelectList(pm.Listele(), "Id", "Ad");
            return View();
        }
        public ActionResult Sil(int id)
        {
            Ilac k = m.Listele().Find(x => x.Id == id);
            if (k == null)
                HttpNotFound();
            return View(k);
        }
        [HttpPost, ValidateAntiForgeryToken, ActionName("Sil")]
        public ActionResult SilOnay(int id)
        {
            Ilac k = m.Listele().Find(x => x.Id == id);
            if (k == null)
                HttpNotFound();
            m.Sil(k);
            return RedirectToAction("Listele");
        }
    }
}