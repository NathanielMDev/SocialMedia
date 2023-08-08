using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace SocialMedia.Data.Comment;

public class Comment
{
    [Key]
    public int Id { get; set; }

    [Required, MinLength(1), MaxLength(256)]
    public string Text { get; set; } = string.Empty;

    [ForeignKey(nameof(Author))]
    public int AuthorId { get; set; }

    public User Author { get; set; } = null!;

    [ForeignKey(nameof(Post))]
    public int PostId { get; set; }

    public Posts Post { get; set; }

    public virtual List<Replies> ReplyList { get; set; } = null!;

}
