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
                                         "~/Scripts/jquery.validate.js",
                                         "~/Scripts/jquery.validate.unobtrusive.js"));

            bundles.Add(new ScriptBundle("~/bundles/change-profile").Include(
                                         "~/Scripts/Views/change-profile.js"));

            bundles.Add(new ScriptBundle("~/bundles/post-message").Include(
                                         "~/Scripts/Views/post-message.js"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                                         "~/Scripts/bootstrap.js"));

            bundles.Add(new ScriptBundle("~/bundles/editor").Include(
                                         "~/Scripts/tinymce/tinymce.js"));

            bundles.Add(new StyleBundle("~/Content/style").Include(
                                        "~/Content/style.css",
                                        "~/Content/bootstrap.css"));
        }
    }
}