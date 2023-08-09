using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SocialMedia.Models;

namespace SocialMedia.Models;

public class LikeCreate
{
    [ForeignKey(nameof(CurrentPost))]
    public int PostId { get; set; }
    public Post CurrentPost { get; set; } = null!;

}