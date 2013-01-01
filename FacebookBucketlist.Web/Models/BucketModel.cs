using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FacebookBucketlist.Web.Models
{
    public class BucketModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public List<ItemModel> Items { get; set; }
    }
}