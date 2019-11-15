using System.Web.Optimization;

namespace Site
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            BundleTable.EnableOptimizations = false;
            var bundle = new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js");
            bundles.Add(bundle);

            bundle = new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*");

            bundles.Add(bundle);

            bundle = new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.min.js",
                      "~/Scripts/respond.js");

            bundles.Add(bundle);

            var styleBundle = new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.min.css",
                      "~/Content/font-awesome.min.css",
                      "~/Content/chosen.css",
                      "~/Content/ngDialog/ngDialog.css",
                      "~/Content/ngDialog/ngDialog-theme-default.css",
                      "~/Content/ngDialog/ngDialog-theme-plain.css",
                      "~/Content/ngDialog/ngDialog-custom-width.css",
                      "~/Content/jquery-ui.min.css",
                      "~/Content/angular-datatables.min.css",
                      "~/Content/datatables.bootstrap.min.css",
                      "~/Content/jquery.dataTables.min.css",
                      "~/Content/angular-toastr.css",
                      "~/Content/site.css",
                      "~/Content/jquery-ui-timepicker-addon.css");

            bundles.Add(styleBundle);

            bundle = new ScriptBundle("~/bundles/angular").Include(
                       "~/App/Lib/angular.min.js",
                       "~/App/Lib/angular-route.js",
                       "~/App/Lib/angular-datatables.min.js",
                       "~/App/Lib/angular-sanitize.js",
                       "~/App/Lib/angular-chosen.js",
                       "~/App/Lib/angular-confirm.js",
                       "~/App/Lib/angular-bootstrap-checkbox.js",
                       "~/App/Lib/ngDialog.js",
                       "~/App/Lib/Chart.bundle.min.js",
                       "~/App/Lib/Chart.min.js",
                       "~/App/Lib/angular-chart.min.js",
                       "~/App/main.js",
                       "~/App/Config/route.js",
                       "~/App/Services/CommonService.js",
                       "~/App/Controllers/PlanoVooController.js",
                       "~/App/Controllers/AeronavesController.js",
                       "~/App/Controllers/AeroportosController.js",
                       "~/App/Controllers/TiposAeronavesController.js",
                       "~/App/Controllers/LayoutController.js",
                       "~/App/Factories/PlanoVooFactory.js",
                       "~/App/Directives/Directives.js"
                       );
            
            bundles.Add(bundle);

            bundle = new ScriptBundle("~/bundles/scripts").Include(
                       "~/Scripts/datatables.min.js",
                       "~/Scripts/jquery-ui.js",
                       "~/Scripts/jquery-ui-sliderAccess.js",
                       "~/Scripts/jquery-ui-timepicker-addon.js",
                       "~/Scripts/chosen.jquery.js",
                       "~/Scripts/jquery.mask.min.js",
                       "~/Scripts/toastr.js"
                       );
            
            bundles.Add(bundle);
        }
    }
}
