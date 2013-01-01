using System.Data.Entity;
using FacebookBucketList.Core.Models;

namespace FacebookBucketList.Core
{
    public class BucketListContext : DbContext
    {

        public BucketListContext() : base("BucketList")
        {
           
        }

        public DbSet<User> Users { get; set; }

        public DbSet<Bucket> Buckets { get; set; }

        public DbSet<BucketItem> Items { get; set; }
    }
}