using EczaneApp.EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EczaneApp.UI.Filters
{
    public class YetkiKontrolAttribute : FilterAttribute, IAuthorizationFilter
    {
        public Yetkiler Yetki { get; set; }
        public void OnAuthorization(AuthorizationContext filterContext)
        {
            if(filterContext.HttpContext.Session["user"] != null)
            {
                Kullanici k = filterContext.HttpContext.Session["user"] as Kullanici;
                if (k != null && k.Yetki == Yetki) return;
            }
            filterContext.Result = new ViewResult()
            {
                ViewName = "ErisimRed"
            };
        }
    }
}