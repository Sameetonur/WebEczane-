using EczaneApp.EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Filters;

namespace EczaneApp.UI.Filters
{
    public class KimlikKontrolAttribute : FilterAttribute, IAuthenticationFilter
    {
        public void OnAuthentication(AuthenticationContext filterContext)
        {
            if(filterContext.HttpContext.Session["user"] != null)
            {
                Kullanici k = filterContext.HttpContext.Session["user"] as Kullanici;
                if (k != null) return;
            }
            filterContext.Result = new HttpUnauthorizedResult();
        }

        public void OnAuthenticationChallenge(AuthenticationChallengeContext filterContext)
        {
            if(filterContext.Result != null && filterContext.Result is HttpUnauthorizedResult)
            {
                filterContext.Result = new RedirectToRouteResult(
                    new System.Web.Routing.RouteValueDictionary
                    {
                        {"controller","User" },
                        {"action","Giris" },
                        {"area","" }
                    }
                    );
            }
        }
    }
}