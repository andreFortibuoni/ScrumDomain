using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Raven.Client;
using Raven.Client.Document;

namespace ScrumWebApplication
{
    public class MvcApplication : System.Web.HttpApplication
    {
        public static IDocumentStore RavenDbDocumentStore { get; private set; }
        private static void CreateRavenDbDocumentStore()
        {
            RavenDbDocumentStore = new DocumentStore{
                ConnectionStringName = "ravenDB"
            }.Initialize();
        }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            CreateRavenDbDocumentStore();
        }
    }
}
