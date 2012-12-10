using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace BucketList.Infrastructure
{
    public class ResourceBundler
    {
        private readonly BundleCollection _bundles;

        public ResourceBundler(BundleCollection bundles)
        {
            _bundles = bundles;
        }

        public void AddBundles()
        {
            _bundles.Add(GetScriptBundle());
            _bundles.Add(GetStyleBundle());
        }

        private Bundle GetStyleBundle()
        {
            throw new NotImplementedException();
        }

        private Bundle GetScriptBundle()
        {
            throw new NotImplementedException();
        }
    }
}