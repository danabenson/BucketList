using System.Web.Optimization;

namespace FacebookBucketlist.Web
{
    public class BundleConfig
    {
        // For more information on Bundling, visit http://go.microsoft.com/fwlink/?LinkId=254725
        public static void RegisterBundles(BundleCollection bundles)
        {
            var styles = new StyleBundle("~/Content/css");
            styles.IncludeDirectory("~/Content/", "*.css", true);
            bundles.Add(styles);

            var scripts = new ScriptBundle("~/Scripts");
            scripts.IncludeDirectory("~/Scripts/", "*.js", true);
            bundles.Add(scripts);
        }
    }
}