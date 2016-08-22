using System.Linq;
using System.Web.Mvc;
using Umbraco.Core;
using Umbraco.Web;
using Umbraco.Web.Mvc;

namespace Umbraco.BackofficeDocumentor.Controllers
{
   
  
    public class BackofficeVisualizerController : UmbracoAuthorizedController
    {
        // GET: BackofficeVisualizer
        public ActionResult Index()
        {
            if(!UmbracoContext.Current.Security.CurrentUser.AllowedSections.Any(x=>x.Equals("developer")))
                return new HttpUnauthorizedResult();

            var visualizer = new Services.BackofficeDocumentor();
            var snapshot = visualizer.CreateSnapshot();

            return View("~/App_Plugins/UmbracoBackofficeVisualizer/Views/BackofficeVisualizer/Index.cshtml", snapshot);
        }

       
    }
}