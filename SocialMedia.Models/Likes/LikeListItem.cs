using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
//using SocialMedia.Data;

namespace SocialMedia.Models.LikeListItem;

    public class LikeListItem
    {
    [ForeignKey(nameof(CurrentPost))]
    public int PostId { get; set; }
    public Post CurrentPost { get; set; } = null!;

    [Key]
    public int OwnerId { get; set; }

    public int Id { get; set; }
    }
