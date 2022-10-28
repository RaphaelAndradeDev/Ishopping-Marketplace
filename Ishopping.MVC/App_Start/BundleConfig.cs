using System.Web;
using System.Web.Optimization;

namespace Ishopping.MVC
{  
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            BundleTable.EnableOptimizations = false;

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*")); 

            // Single bootstrap layout
            bundles.Add(new StyleBundle("~/bundles/singleBootstrap-css").Include(
                    "~/Content/bootstrap.css",
                    "~/Content/site.css"));

            bundles.Add(new ScriptBundle("~/bundles/singleBootstrap-js").Include(
                    "~/Scripts/modernizr-*",
                    "~/Scripts/jquery-1.10.2.js",
                    "~/Scripts/bootstrap.js"));
            

            // Ishopping default layout
            bundles.Add(new ScriptBundle("~/bundles/default-css").Include(
                    "~/Content/bootstrap.css",
                    "~/Content/bootstrapValidator.css",
                    "~/Content/site.css"));

            bundles.Add(new ScriptBundle("~/bundles/default-js").Include(
                    "~/Scripts/modernizr-*",
                    "~/Scripts/jquery-1.10.2.js",
                    "~/Scripts/bootstrap.js",
                    "~/Scripts/bootstrapValidator.js",
                    "~/Scripts/language/pt_BR.js",
                //Ishopping js
                    "~/Scripts/Ishopping/SetAppMenu.min.js"));


            // Ishopping basic layout
            bundles.Add(new ScriptBundle("~/bundles/basic-css").Include(
                    "~/Content/jquery-ui.min.css",
                    "~/Content/bootstrap.css",
                    "~/Content/bootstrapValidator.css",
                    "~/Content/bootstrap_select/css/bootstrap-select.min.css",
                    "~/Content/site.css"));

            bundles.Add(new ScriptBundle("~/bundles/basic-js").Include(
                    "~/Scripts/modernizr-*",
                    "~/Scripts/jquery-1.10.2.js",
                    "~/Scripts/jquery-ui.min.js",
                    "~/Scripts/jquery.unobtrusive-ajax*",
                    "~/Scripts/bootstrap.js",                    
                    "~/Scripts/bootstrapValidator.js",
                    "~/Scripts/language/pt_BR.js",                    
                    "~/Content/bootstrap_select/js/bootstrap-select.min.js",                    
                    //Ishopping js
                    "~/Scripts/Ishopping/SetAppMenu.min.js",
                    "~/Scripts/Ishopping/CommunTags.min.js",
                    "~/Scripts/Ishopping/ModalStyle.min.js",
                    "~/Scripts/Ishopping/CommunEntity.min.js"));
        }
    }    
}
