using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BucketList.Infrastructure.Data
{
    public class BucketList
    {
        public List<BucketListItem> Items { get; set; }

        public User User { get; set; }
    }
}