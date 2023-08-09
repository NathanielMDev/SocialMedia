using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SocialMedia.Models;


namespace SocialMedia.Models;

public class LikeCreate
{
    [Key]
    public int PostId { get; set; }
}