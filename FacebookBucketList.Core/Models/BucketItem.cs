using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacebookBucketList.Core.Models
{
    public class BucketItem
    {
        [Key]
        public int Id { get; set; }

        public string Text { get; set; }

        public DateTime Created { get; set; }

        public DateTime Completed { get; set; }
    }
}
