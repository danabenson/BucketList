using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BucketList.Infrastructure.Data
{
    public class BucketListItem
    {
        public string Text { get; set; }

        public bool Completed { get; set; }

        public DateTime? CompletedDate { get; set; }
    }
}