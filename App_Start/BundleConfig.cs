using System.Web;
using System.Web.Optimization;

namespace Buyalot
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-1.9.1.js",
                        "~/Scripts/jquery-1.9.1.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*",
                         "~/Scripts/jquery.validate.js",
                        "~/Scripts/jquery.validate.min.js",
                        "~/Scripts/jquery.validate-vsdoc.j",
                        "~/Scripts/jquery.validate.unobtrusive.js"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/bootstrap.min.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/bootstrap.min.css",
                      "~/Content/Site.css"));

            bundles.Add(new ScriptBundle("~/bundles/AngularApp")
                    .Include("~/Scripts/angular.js")
                    .Include("~/Scripts/angular.min.js")
                    .Include("~/Scripts/angular-route.js")
                    .Include("~/Scripts/angular-route.min.js")
                    .Include("~/Scripts/angular-ui/ui-bootstrap-tpls.js")
                    .Include("~/Scripts/angular-ui/ui-bootstrap-min.js")
                    .Include("~/Scripts/angular-ui/ui-bootstrap.js")
                    .Include("~/Scripts/angular-ui/ui-bootstrap-tpls.min.js")
                    .Include("~/Scripts/angular-animate.js")
                    .Include("~/Scripts/lib/angular-input-match.js")
                    .Include("~/Scripts/lib/showErrors.js")
                    .Include("~/Scripts/lib/loading-bar.js")

                    .Include("~/app/AngularApp.js")
                    .IncludeDirectory("~/app/Services", "*.js")
                    .IncludeDirectory("~/app/Controllers", "*.js")
                    );

            BundleTable.EnableOptimizations = false;// !Debugger.IsAttached;
        }
    }
}