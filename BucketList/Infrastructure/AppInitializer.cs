using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;
using AutoMapper;

namespace BucketList.Infrastructure
{
    public class AppInitializer
    {
        public AppInitializer()
        {
            
        }

        public void Initialize()
        {
            var bundler = new ResourceBundler(BundleTable.Bundles);
            bundler.AddBundles();

            Mapper.AssertConfigurationIsValid();
        }
    }
}