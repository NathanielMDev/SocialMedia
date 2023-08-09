using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
//using SocialMedia.Data;

namespace SocialMedia.Models.LikeListItem;

    public class LikeListItem
    {
    [Key]
    public int PostId { get; set; }

    [Key]
    public int OwnerId { get; set; }

    public int Id { get; set; }
    }
