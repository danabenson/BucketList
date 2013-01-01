using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacebookBucketList.Core.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        public string FacebookId { get; set; }

        [Required]
        public Bucket Bucket { get; set; }
    }
}
