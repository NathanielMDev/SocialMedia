using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SocialMedia.Data;

namespace SocialMedia.Data.Likes;

    public class Likes
    {
        [Key]
        public int Id { get; set; } 
        
        [ForeignKey(nameof(OriginalPost))]
        public int PostId { get; set; }
        public List<Post> OriginalPost { get; set; } = null!;
    
        [ForeignKey(nameof(CurrentUser))]
        public int UserId { get; set; }

        public User CurrentUser { get; set; } = null!;

        [Key]
        public int OwnerId { get; set; }
    }
