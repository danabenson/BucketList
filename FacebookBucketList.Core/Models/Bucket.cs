using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacebookBucketList.Core.Models
{
    public class Bucket
    {
        public Bucket()
        {
            Items = new List<BucketItem>();
        }

        [Key]
        public int Id { get; set; }

        public List<BucketItem> Items { get; set; }

        public User User { get; set; }
    }
}
