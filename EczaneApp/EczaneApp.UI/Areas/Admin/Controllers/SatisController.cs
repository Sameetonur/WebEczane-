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
    public class SatisController : Controller
    {
        // GET: Admin/Satis
        SatisManager m = new SatisManager();
        public ActionResult Listele()
        {
            return View(m.Listele());
        }
        public ActionResult SatisDetay(int id)
        {
            Satis satis = m.Listele().Find(x=> x.Id == id);
            if (satis == null)
                return HttpNotFound();
            using (SatisDetaylarManager detayManager = new SatisDetaylarManager())
                return View(detayManager.Listele().Where(x=> x.SatisId == satis.Id).ToList());
        }
        public ActionResult Sil(int id)
        {
            Satis k = m.Listele().Find(x => x.Id == id);
            if (k == null)
                HttpNotFound();
            return View(k);
        }
        [HttpPost, ValidateAntiForgeryToken, ActionName("Sil")]
        public ActionResult SilOnay(int id)
        {
            Satis k = m.Listele().Find(x => x.Id == id);
            if (k == null)
                HttpNotFound();
            m.Sil(k);
            return RedirectToAction("Listele");
        }
    }
}