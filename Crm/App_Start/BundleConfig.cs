using System.Web;
using System.Web.Optimization;

namespace Crm
{
    public class BundleConfig
    {
        // Per altre informazioni sulla creazione di bundle, vedere https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Utilizzare la versione di sviluppo di Modernizr per eseguire attività di sviluppo e formazione. Successivamente, quando si è
            // pronti per passare alla produzione, usare lo strumento di compilazione disponibile all'indirizzo https://modernizr.com per selezionare solo i test necessari.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"
                      ));

            bundles.Add(new ScriptBundle("~/bundles/toastr").Include(
                                          "~/Scripts/toastr.js",
                                          "~/Scripts/toastr.min.js"

                    ));
            bundles.Add(new ScriptBundle("~/bundles/myscripts").Include(
                     "~/Scripts/index.js",
                      "~/Scripts/IconManagement.js",
                      "~/Scripts/Menu.js",
                      "~/Scripts/crm-utilities.js",
                      "~/Scripts/CustomAsyncModal.js"
                ));
            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/Site.css",
                      "~/Content/Spinner.css",
                      "~/Content/NavigationBar.css",
                      "~/Content/FilterForDataVisualization.css",
                      "~/Content/crm-graphic.css",
                      "~/Content/Colors.css",
                      "~/Content/Icon.css",
                      "~/Content/crm-menu.css",
                      "~/Content/crm-DetailsPage.css",
                      "~/Content/toastr.css",
                      "~/Content/HomeStyle.css"
                      ));
        }
    }
}
