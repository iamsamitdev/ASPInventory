using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace ASPInventory.App_Start
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {

            // Frontend ----------------------------------------------------------------------
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                "~/Scripts/jquery-{version}.js"
            ));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                "~/Scripts/bootstrap.js"
            ));

            bundles.Add(new ScriptBundle("~/bundles/popper").Include(
                "~/Scripts/popper.js"
            ));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                "~/Content/bootstrap.css",
                "~/Content/custom.css"
            ));

            // Backend ----------------------------------------------------------------------
            bundles.Add(new ScriptBundle("~/bundles/backendjs").Include(
               "~/Scripts/backend/vendor/jquery/jquery.js",
               "~/Scripts/backend/vendor/bootstrap/js/bootstrap.js",
               "~/Scripts/backend/vendor/jquery-easing/jquery.easing.js",
               "~/Scripts/backend/js/sb-admin-2.js"
           ));

            bundles.Add(new StyleBundle("~/Content/backendcss").Include(
               "~/Content/backend/css/sb-admin-2.css",
                "~/Scripts/backend/vendor/fontawesome-free/css/all.css",
               "~/Content/backend/css/custom.css"
           ));

        }
    }
}