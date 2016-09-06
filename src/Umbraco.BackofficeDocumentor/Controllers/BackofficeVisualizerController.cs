using System;
using System.IO;
using System.Linq;
using System.Web.Mvc;
using Umbraco.BackofficeDocumentor.Services;
using Umbraco.Core;
using Umbraco.Web;
using Umbraco.Web.Mvc;

namespace Umbraco.BackofficeDocumentor.Controllers
{
    public class BackofficeVisualizerController : UmbracoAuthorizedController
    {
        private IBackofficeDocumentor _visualizer;
        private ISnapshotService _snapshot;


        public BackofficeVisualizerController()
        {
            this._visualizer = new Services.BackofficeDocumentor();
            this._snapshot = new SnapshotService();
        }
        // GET: BackofficeVisualizer
        public ActionResult Index(string file=null)
        {
            return Html(fileName:file);
        }


       

        public ActionResult AsDoc(string file=null)
        {
            return Html(isDoc:true,fileName:file);
        }

        private ActionResult Html(string fileName=null, bool isDoc=false)
        {
            if (!UmbracoContext.Current.Security.CurrentUser.AllowedSections.Any(x => x.Equals("developer")))
                return new HttpUnauthorizedResult();
          
            var snapshot =fileName!=null  ?_snapshot.Get(fileName) :  _visualizer.CreateSnapshot();
            if (isDoc)
            {
                ViewBag.IsDoc = true;
                Response.ContentType = "application/msword";
                Response.Headers.Set("Content-Disposition", string.Format("attachment; filename={0}.doc",fileName!=null ? Path.GetFileNameWithoutExtension(fileName) : Guid.NewGuid().ToString()));
            }
          

            return View("~/App_Plugins/UmbracoBackofficeVisualizer/Views/BackofficeVisualizer/Index.cshtml", snapshot);
        }
    }
}