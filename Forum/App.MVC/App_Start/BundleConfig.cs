using System.Web.Optimization;

namespace App.MVC
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                                         "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/validation").Include(
                                         "~/Scripts/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/change-profile").Include(
                                         "~/Scripts/Views/change-profile.js"));

            bundles.Add(new StyleBundle("~/Content/forum-style").Include(
                                        "~/Content/style.css"));
        }
    }
}