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
            return Html();
        }


        // GET: BackofficeVisualizer
        public ActionResult Json()
        {
            if (!UmbracoContext.Current.Security.CurrentUser.AllowedSections.Any(x => x.Equals("developer")))
                return new HttpUnauthorizedResult();

            var visualizer = new Services.BackofficeDocumentor();
            var snapshot = visualizer.CreateSnapshot();

            return Json(snapshot,JsonRequestBehavior.AllowGet);
        }

        public ActionResult AsDoc()
        {
            return Html(true);
        }

        private ActionResult Html(bool isDoc=false)
        {
            if (!UmbracoContext.Current.Security.CurrentUser.AllowedSections.Any(x => x.Equals("developer")))
                return new HttpUnauthorizedResult();
            var visualizer = new Services.BackofficeDocumentor();
            var snapshot = visualizer.CreateSnapshot();
            if (isDoc)
            {
                Response.ContentType = "application/msword";
                Response.Headers.Set("Content-Disposition", "attachment; filename=documentation.doc");
            }
          

            return View("~/App_Plugins/UmbracoBackofficeVisualizer/Views/BackofficeVisualizer/Index.cshtml", snapshot);
        }
    }
}