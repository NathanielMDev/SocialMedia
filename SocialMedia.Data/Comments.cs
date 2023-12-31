using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace SocialMedia.Data;

public class Comment
{
    [Key]
    public int Id { get; set; }
    
    [Required, MinLength(1), MaxLength(256)]
    public string Text { get; set; } = string.Empty;
    [Required]
    [ForeignKey(nameof(Author))]
    public int AuthorId { get; set; }
    public User Author { get; set; } = null!;
    [Required]
    [ForeignKey(nameof(OriginalPost))]
    public int PostId { get; set; }
    public Post OriginalPost { get; set; } = null!;

//    public virtual List<Replies> ReplyList { get; set; } = null!;

}
