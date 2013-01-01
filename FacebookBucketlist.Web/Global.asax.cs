using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using FacebookBucketlist.Web.Infrastructure;
using Microsoft.AspNet.Mvc.Facebook;
using Ninject;
using Ninject.Web.Common;

namespace FacebookBucketlist.Web
{
    public class MvcApplication : HttpApplication
    {
        private static AppInitializer _app;

        public MvcApplication()
        {
            _app = new AppInitializer();
        }

        protected void Application_Start()
        {
            _app.Start();
        }
    }
}