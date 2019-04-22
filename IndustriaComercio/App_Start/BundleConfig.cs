using System.Web;
using System.Web.Optimization;

namespace IndustriaComercio
{
    public static class BundleConfig
    {
        // Para obtener más información sobre las uniones, visite https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new StyleBundle("~/bundles/css").Include(
                      "~/Content/vendor/bootstrap/css/bootstrap.min.css",
                      "~/Content/vendor/fontawesome-free/css/all.min.css",
                      "~/Content/vendor/datatables/dataTables.bootstrap4.css",
                      "~/Content/vendor/printjs/print.min.css",
                      "~/Content/vendor/vue/vue-select/vue-select.css",
                      "~/Content/css/sb-admin.css",
                      "~/Content/css/main.css",
                      "~/Content/css/toastr.min.css"
                      ));

               bundles.Add(new ScriptBundle("~/bundles/js").Include(
                        "~/Content/vendor/jquery/jquery.min.js",
                        "~/Content/vendor/bootstrap/js/bootstrap.bundle.min.js",
                        "~/Content/vendor/jquery-easing/jquery.easing.min.js",
                        "~/Content/vendor/axios/axios.min.js",
                        "~/Content/vendor/Numeral/numeral.min.js",
                        "~/Content/vendor/Numeral/locales.min.js",
                        "~/Content/vendor/vue/vue.min.js",
                        "~/Content/vendor/vue/vee-validate/vee-validate.js",
                        "~/Content/vendor/vue/vuetable/vuetable-2.js",
                        "~/Content/vendor/vue/vue-select/vue-select.js",
                        "~/Content/vendor/lodash/lodash.js",
                        "~/Content/vendor/SweetAlert/sweetalert2@8.js",
                        "~/Content/vendor/printjs/print.min.js",
                        "~/Content/js/functions.js",
                        "~/Content/js/sb-admin.min.js"
                        ));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*",
                        "~/Scripts/toastr.min.js"));


        }
    }
}
