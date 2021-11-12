using System.Web;
using System.Web.Optimization;

namespace KavisWeb
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Areas/Kavis/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Areas/Kavis/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/Areas/Kavis/bundles/modernizr").Include(
                        "~/Areas/Kavis/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Areas/Kavis/Scripts/bootstrap.js"));

            bundles.Add(new StyleBundle("~/Areas/Kavis/Content/css").Include(
                      "~/Areas/Kavis/Content/bootstrap.css",
                      "~/Areas/Kavis/Content/site.css",
                      "~/Areas/Kavis/Content/font-awesome.css"));
        }
    }
}
