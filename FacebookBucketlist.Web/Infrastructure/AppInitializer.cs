using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Microsoft.AspNet.Mvc.Facebook;
using Ninject;

namespace FacebookBucketlist.Web.Infrastructure
{
    public class AppInitializer
    {
        public void Start()
        {
            AreaRegistration.RegisterAllAreas();
            FacebookConfig.Register(GlobalFacebookConfiguration.Configuration);
            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}