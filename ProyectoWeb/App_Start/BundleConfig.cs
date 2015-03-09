using BundleTransformer.Core.Bundles;
using BundleTransformer.Core.Orderers;
using BundleTransformer.Core.Transformers;
using System.Web.Optimization;

namespace ASP.NET_MVC5_Bootstrap3_3_1_LESS
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.UseCdn = true;
            var cssTransformer = new StyleTransformer();
            var jsTransformer = new ScriptTransformer();
            var nullOrderer = new NullOrderer();

            var cssBundle = new StyleBundle("~/bundles/css");
            cssBundle.Include( "~/Content/bootstrap/bootstrap.less", "~/Content/css/font-awesome.css", "~/Content/css/custom.css");
            cssBundle.Transforms.Add(cssTransformer);
            cssBundle.Orderer = nullOrderer;
            bundles.Add(cssBundle);

            var cssLoginBundle = new StyleBundle("~/bundles/login");
            cssLoginBundle.Include("~/Content/bootstrap/bootstrap.less", "~/Content/css/font-awesome.css", "~/Content/css/custom.css", "~/Content/css/login.css");
            cssLoginBundle.Transforms.Add(cssTransformer);
            cssLoginBundle.Orderer = nullOrderer;
            bundles.Add(cssLoginBundle);

            var cssDataTableBundle = new StyleBundle("~/bundles/cssDataTable");
            cssDataTableBundle.Include( "~/Content/css/dataTables.bootstrap.css");
            cssDataTableBundle.Transforms.Add(cssTransformer);
            cssDataTableBundle.Orderer = nullOrderer;
            bundles.Add(cssDataTableBundle);

            var jqueryBundle = new ScriptBundle("~/bundles/jquery");
            jqueryBundle.Include("~/Scripts/jquery-{version}.js", "~/Scripts/js/morris-0.4.3.min.js");
            jqueryBundle.Transforms.Add(jsTransformer);
            jqueryBundle.Orderer = nullOrderer;
            bundles.Add(jqueryBundle);

            var jqueryvalBundle = new ScriptBundle("~/bundles/jqueryval");
            jqueryvalBundle.Include("~/Scripts/jquery.validate*");
            jqueryvalBundle.Transforms.Add(jsTransformer);
            jqueryvalBundle.Orderer = nullOrderer;
            bundles.Add(jqueryvalBundle);

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.

            var modernizrBundle = new ScriptBundle("~/bundles/modernizr");
            modernizrBundle.Include("~/Scripts/modernizr-*");
            modernizrBundle.Transforms.Add(jsTransformer);
            modernizrBundle.Orderer = nullOrderer;
            bundles.Add(modernizrBundle);

            var bootstrapBundle = new ScriptBundle("~/bundles/bootstrap");
            bootstrapBundle.Include("~/Scripts/bootstrap.js", "~/Scripts/respond.js",  "~/Scripts/js/jquery.metisMenu.js", "~/Scripts/js/raphael-2.1.0.min.js", "~/Scripts/js/morris.js", "~/Scripts/js/custom.js","~/Scripts/js/jquery.bootpag.min.js", "~/Scripts/js/validate.js");
            bootstrapBundle.Transforms.Add(jsTransformer);
            bootstrapBundle.Orderer = nullOrderer;
            bundles.Add(bootstrapBundle);

            var dataTableBundle = new ScriptBundle("~/bundles/datatable");
            dataTableBundle.Include("~/Scripts/js/jquery.js", "~/Scripts/js/jquery.dataTables.js", "~/Scripts/js/dataTablesBootstrap.js", "~/Scripts/js/util.js");
            dataTableBundle.Transforms.Add(jsTransformer);
            dataTableBundle.Orderer = nullOrderer;
            bundles.Add(dataTableBundle);

            var dataTable2Bundle = new ScriptBundle("~/bundles/datatable2");
            dataTable2Bundle.Include("~/Scripts/js/jquery.js", "~/Scripts/js/jquery.dataTables.js", "~/Scripts/js/dataTablesBootstrap.js");
            dataTable2Bundle.Transforms.Add(jsTransformer);
            dataTable2Bundle.Orderer = nullOrderer;
            bundles.Add(dataTable2Bundle);



            var procesoBundle = new ScriptBundle("~/bundles/proceso");
            procesoBundle.Include("~/Scripts/js/proceso.js");
            procesoBundle.Transforms.Add(jsTransformer);
            procesoBundle.Orderer = nullOrderer;
            bundles.Add(procesoBundle);

            var buscarBundle = new ScriptBundle("~/bundles/buscar");
            buscarBundle.Include("~/Scripts/js/buscar.js");
            buscarBundle.Transforms.Add(jsTransformer);
            buscarBundle.Orderer = nullOrderer;
            bundles.Add(buscarBundle);

            var informacionBundle = new ScriptBundle("~/bundles/informacion");
            informacionBundle.Include("~/Scripts/js/popup.js", "~/Scripts/js/informacion.js");
            informacionBundle.Transforms.Add(jsTransformer);
            informacionBundle.Orderer = nullOrderer;
            bundles.Add(informacionBundle);

        }
    }
}