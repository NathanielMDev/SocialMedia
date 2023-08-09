using System.ComponentModel.DataAnnotations;

namespace SocialMedia.Models.Likes
{
    public class LikeUpdate
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [ForeignKey(nameof(CurrentPost))]
        public int PostId { get; set; }
        public Post CurrentPost { get; set; } = null!;
    }
}