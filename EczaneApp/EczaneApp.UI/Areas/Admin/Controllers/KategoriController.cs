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
    public class KategoriController : Controller
    {
        // GET: Admin/Kategori
        KategoriManager m = new KategoriManager();
        public ActionResult Listele()
        {
            return View(m.Listele());
        }
        public ActionResult Ekle()
        {
            return View();
        }
        [HttpPost,ValidateAntiForgeryToken]
        public ActionResult Ekle(Kategori k)
        {
            if(ModelState.IsValid)
            {
                m.Ekle(k);
                return RedirectToAction("Listele");
            }
            return View();
        }
        public ActionResult Duzenle(int id)
        {
            Kategori k = m.Listele().Find(x=> x.Id == id);
            if (k == null)
                HttpNotFound();
            return View(k);
        }
        [HttpPost,ValidateAntiForgeryToken]
        public ActionResult Duzenle(Kategori k)
        {
            if (ModelState.IsValid)
            {
                m.Guncelle(k);
                return RedirectToAction("Listele");
            }
            return View();
        }
        public ActionResult Sil(int id)
        {
            Kategori k = m.Listele().Find(x => x.Id == id);
            if (k == null)
                HttpNotFound();
            return View(k);
        }
        [HttpPost,ValidateAntiForgeryToken,ActionName("Sil")]
        public ActionResult SilOnay(int id)
        {
            Kategori k = m.Listele().Find(x => x.Id == id);
            if (k == null)
                HttpNotFound();
            m.Sil(k);
            return RedirectToAction("Listele");
        }
    }
}