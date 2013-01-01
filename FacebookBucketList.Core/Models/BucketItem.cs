using System;
using System.ComponentModel.DataAnnotations;

namespace FacebookBucketList.Core.Models
{
    public class BucketItem
    {
        [Key]
        public int Id { get; set; }

        public string Text { get; set; }

        public DateTime Created { get; set; }

        public DateTime? Completed { get; set; }

        [Required]
        public Bucket Bucket { get; set; }
    }
}