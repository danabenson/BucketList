using System.ComponentModel.DataAnnotations;

namespace FacebookBucketList.Core.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        public string ProfileImageUrl { get; set; }

        public string FacebookId { get; set; }

        public Bucket Bucket { get; set; }
    }
}