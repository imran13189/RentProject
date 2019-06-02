using System.Web;
using System.Web.Optimization;

namespace Rent
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Content/assets/js/jquery-3.3.1.js",
                        "~/Scripts/jquery.validate.min.js",
                        "~/Scripts/Custom/ApiUrls.js"
                        ));

            bundles.Add(new ScriptBundle("~/bundles/jquerybottom").Include(
                       "~/Content/assets/js/modernizr-2.6.2.min.js",
                       "~/Content/bootstrap/js/bootstrap.min.js",
                       "~/Content/assets/js/bootstrap-select.min.js",
                       "~/Content/assets/js/bootstrap-hover-dropdown.js",
                       "~/Content/assets/js/easypiechart.min.js",
                       "~/Content/assets/js/jquery.easypiechart.min.js",
                       "~/Content/assets/js/owl.carousel.min.js",
                       "~/Content/assets/js/wow.js",
                       "~/Content/assets/js/icheck.min.js",
                       "~/Content/assets/js/price-range.js",
                       "~/Content/assets/js/main.js"
                       ));

            //// Use the development version of Modernizr to develop with and learn from. Then, when you're
            //// ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            //bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
            //            "~/Scripts/modernizr-*"));

            //bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
            //          "~/Scripts/bootstrap.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/assets/css/normalize.css",
                      "~/Content/assets/css/fontello.css",
                      "~/Content/assets/fonts/icon-7-stroke/css/pe-icon-7-stroke.css",
                      "~/Content/assets/fonts/icon-7-stroke/css/helper.css",
                      "~/Content/assets/css/animate.css",
                      "~/Content/assets/css/bootstrap-select.min.css",
                      "~/Content/bootstrap/css/bootstrap.min.css",
                      "~/Content/assets/css/icheck.min_all.css",
                      "~/Content/assets/css/price-range.css",
                      "~/Content/assets/css/owl.carousel.css",
                      "~/Content/assets/css/owl.theme.css",
                      "~/Content/assets/css/owl.transitions.css",
                      "~/Content/assets/css/style.css",
                      "~/Content/assets/css/responsive.css",
                      "~/Content/Site.css"
                     ).Include("~/Content/assets/css/font-awesome.min.css", new CssRewriteUrlTransform())); ;
        }
    }
}
