using System.IO;
using System.Linq;
using System.Web.Hosting;
using System.Xml.Linq;
using Umbraco.Core;
using Umbraco.Core.Logging;
using Umbraco.Web;

namespace Umbraco.BackofficeDocumentor
{
    public class Dashboard
    {
        public static void Install()
        {
            LogHelper.Info<Dashboard>("Opening Dashboard File");
            const string dashboradPath = "~/Config/Dashboard.config";
         
            var filePath = HostingEnvironment.MapPath(dashboradPath);
            LogHelper.Info<Dashboard>("Opening Dashboard " + filePath);
            if (!File.Exists(filePath))
            {
                LogHelper.Info<Dashboard>("No such file");
                return;
            } ;
            var xdoc = XDocument.Load(filePath);
            LogHelper.Info<Dashboard>("Getting dashboard node");
            var dashboard = xdoc.Root;
            if (dashboard == null)
                return;
            var sections = dashboard.Descendants("section");
            LogHelper.Info<Dashboard>("Getting sections");
            var section =
                sections.FirstOrDefault(
                    x => x.Attribute("alias") != null && x.Attribute("alias").Value == "backofficeDocumentor");
           
            if (section != null)
                return;
            LogHelper.Info<Dashboard>("Adding section");
            section = XElement.Parse("  <section alias=\"backofficeDocumentor\">" +
                                     "                 <areas>" +
                                     "                     <area>" +
                                     "                             developer" +
                                     "                     </area>" +
                                     "                 </areas>" +
                                     "                 <tab caption=\"Documentor\">" +
                                     "                         <control>" +
                                     "                             /App_Plugins/UmbracoBackofficeVisualizer/dashboard.htm" +
                                     "                         </control>" +
                                     "                 </tab>" +
                                     "     </section>");


            dashboard.Add(section);
            LogHelper.Info<Dashboard>("saving");
            xdoc.Save(filePath);

           

            try
            {
                ApplicationContext.Current.RestartApplicationPool(UmbracoContext.Current.HttpContext);
            }
            catch 
            {
                
            }
           




        }
    }
}