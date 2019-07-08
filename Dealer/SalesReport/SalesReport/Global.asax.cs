
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

using SalesReport.Models.Data;

namespace SalesReport
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            //Remove it on production to not lose data. 
            //This is used to develop, and to debug Entity Framework CODEFIRST at SalesDBContext.
            Database.SetInitializer<SalesDBContext>(new DropCreateDatabaseIfModelChanges<SalesDBContext>());
            //--------------------//

            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
