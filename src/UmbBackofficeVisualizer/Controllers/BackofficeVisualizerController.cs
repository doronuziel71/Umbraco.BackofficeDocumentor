using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SelectPdf;
using Umbraco.Web.Mvc;

namespace UmbBackofficeVisualizer.Controllers
{
    [PluginController("UmbracoBackofficeVisualizer")]
    public class BackofficeVisualizerController : Controller
    {
        // GET: BackofficeVisualizer
        public ActionResult Index()
        {
            var visualizer = new UmbBackofficeVisualizer.Services.BackofficeDocumentor();
            var snapshot = visualizer.CreateSnapshot();

            return View("~/App_Plugins/UmbracoBackofficeVisualizer/Views/BackofficeVisualizer/Index.cshtml", snapshot);
        }

       
    }
}