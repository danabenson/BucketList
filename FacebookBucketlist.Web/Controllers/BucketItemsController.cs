using System;
using System.Linq;
using System.Web.Mvc;
using FacebookBucketList.Core;
using FacebookBucketList.Core.Models;

namespace FacebookBucketlist.Web.Controllers
{
    public class BucketItemsController : Controller
    {
        private readonly BucketListContext _context;

        public BucketItemsController(BucketListContext context)
        {
            _context = context;
        }

        [HttpPost]
        public ActionResult Index(string text, int? id, int bucketId)
        {
            BucketItem bi;
            if (id.HasValue)
            {
                bi = _context.Items.Include("Bucket").FirstOrDefault(x => x.Id == id.Value);
                bi.Text = text;
                _context.SaveChanges();
            }
            else
            {
                bi = new BucketItem();
                bi.Text = text;
                bi.Created = DateTime.Now;
                bi.Bucket = _context.Buckets.FirstOrDefault(x => x.Id == bucketId);
                _context.Items.Add(bi);
                _context.SaveChanges();
            }
            return Json(bi.Id);
        }
    }
}