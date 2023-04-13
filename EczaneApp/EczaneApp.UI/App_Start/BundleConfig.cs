using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace EczaneApp.UI.App_Start
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new StyleBundle("~/site/dataCSS").Include("~/Content/dataTables.bootstrap.min.css"));
            bundles.Add(new ScriptBundle("~/site/dataJS").Include("~/Scripts/jquery.dataTables.min.js", "~/Scripts/dataTables.bootstrap.min.js"));

            bundles.Add(new StyleBundle("~/site/css").Include("~/Content/Site.css", "~/Content/bootstrap.min.css"));
            bundles.Add(new ScriptBundle("~/site/js").Include("~/Scripts/jquery-3.5.1.min.js", "~/Scripts/bootstrap.min.js"));


            BundleTable.EnableOptimizations = true;
        }
    }
}