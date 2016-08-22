using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Umbraco.Core;

namespace UmbBackofficeVisualizer
{
    public class Bootstrap : ApplicationEventHandler
    {
        protected override void ApplicationStarted(UmbracoApplicationBase umbracoApplication, ApplicationContext applicationContext)
        {
            base.ApplicationStarted(umbracoApplication, applicationContext);
            RouteTable.Routes.MapRoute("BackofficeVisualizer", "visualize",
                new {controller = "BackofficeVisualizer", action = "Index", area = "UmbracoBackofficeVisualizer"});

       
        }
    }
}