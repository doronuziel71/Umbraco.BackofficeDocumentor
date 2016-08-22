using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using umbraco.BusinessLogic;
using Umbraco.Core;

namespace Umbraco.BackofficeDocumentor
{
    public class Bootstrap : ApplicationEventHandler
    {
        protected override void ApplicationInitialized(UmbracoApplicationBase umbracoApplication, ApplicationContext applicationContext)
        {
            base.ApplicationInitialized(umbracoApplication, applicationContext);
               Dashboard.Install();
        }

        protected override void ApplicationStarted(UmbracoApplicationBase umbracoApplication, ApplicationContext applicationContext)
        {
            base.ApplicationStarted(umbracoApplication, applicationContext);
            RouteTable.Routes.MapRoute("BackofficeVisualizer", "umbraco/backoffice/{controller}/{action}/{id}",
                new {controller = "BackofficeVisualizer", action = "Index", id=UrlParameter.Optional});

         
        }
    }
}