using System.ComponentModel.DataAnnotations;


namespace SocialMedia.Models.Likes
{
    public class LikeUpdate
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [Key]
        public int PostId { get; set; }
    
    }
}