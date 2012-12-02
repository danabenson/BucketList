using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BucketList.Infrastructure.Data
{
    public class BucketListDbContext : DbContext
    {
        public BucketListDbContext() : base("BucketListConnection")
        {
            
        }

        public DbSet<BucketList> BucketList { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<BucketListItem> BucketListItems { get; set; }
    }
}