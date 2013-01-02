using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FacebookBucketList.Core;
using FacebookBucketList.Core.Models;
using FacebookBucketlist.Web.Models;

namespace FacebookBucketlist.Web.Controllers
{
    public class BucketsController : Controller
    {
        private readonly BucketListContext _context;

        public BucketsController(BucketListContext context)
        {
            _context = context;
        }

        public ActionResult View(int bucketId)
        {
            var bucket = _context.Buckets.Include("Items").FirstOrDefault(x => x.Id == bucketId);
            var model = new ViewBucketModel();
            model.Bucket = new BucketModel();
            model.Bucket.Id = bucket.Id;
            model.Bucket.Items = bucket.Items.Select(ItemToModel).ToList();
            return View(model);
        }

        private ItemModel ItemToModel(BucketItem item)
        {
            var model = new ItemModel();
            model.Id = item.Id;
            model.Text = item.Text;
            return model;
        }
    }
}
