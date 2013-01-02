using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FacebookBucketList.Core.Migrations;

namespace FacebookBucketList.Core
{
    public class FacebookBucketListInit : MigrateDatabaseToLatestVersion<BucketListContext, Configuration>
    {
    }
}
