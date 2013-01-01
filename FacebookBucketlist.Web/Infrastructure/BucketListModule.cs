using FacebookBucketList.Core;
using Ninject.Modules;
using Ninject.Web.Common;

namespace FacebookBucketlist.Web.Infrastructure
{
    public class BucketListModule : NinjectModule
    {
        public override void Load()
        {
            Kernel.Bind<BucketListContext>().ToSelf().InRequestScope();
        }
    }
}