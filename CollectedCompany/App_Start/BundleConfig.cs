using System.Web;
using System.Web.Optimization;

namespace CollectedCompany
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/tinymce").IncludeDirectory("~/Scripts/plugins", ".js", true));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/Bootstrap/bootstrap.css",
                      "~/Content/site.css"));

            //Themes
            bundles.Add(new StyleBundle("~/bundles/MarketPlace").IncludeDirectory("~/Themes/MarketPlace/assets/css", "*.css", true));
            bundles.Add(new StyleBundle("~/bundles/MarketPlace/Less").IncludeDirectory("~/Themes/MarketPlace/assets/css", "*.less", true));
            bundles.Add(new ScriptBundle("~/bundles/MarketPlace/Scripts").IncludeDirectory("~/Themes/MarketPlace/assets/js", "*.js", true));





        }
    }
}
