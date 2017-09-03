using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace App.MVC.App_Start
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                                         "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/validation").Include(
                                         "~/Scripts/jquery.validate*"));

            bundles.Add(new StyleBundle("~/Content/forum-style").Include(
                                        "~/Content/style.css"));
        }
    }
}