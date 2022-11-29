using System.Web;
using System.Web.Optimization;

namespace Seafood
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/js").Include());
            bundles.Add(new StyleBundle("~/bundles/css").Include());
        }
    }
}
