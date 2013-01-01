using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FacebookBucketList.Core.Models;

namespace FacebookBucketlist.Web.Models
{
    public class HomeModel
    {
        public string Name { get; set; }

        public Bucket Bucket { get; set; }
    }
}