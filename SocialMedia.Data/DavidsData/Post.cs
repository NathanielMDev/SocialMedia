
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SocialMedia.Data;

public class Posts {
    [Key]
    public int Id { get; set; }

    [Required, MinLength(1), MaxLength(100)]
    public string Title { get; set; } = string.Empty;

    [Required, MinLength(1), MaxLength(800)]
    public string Text { get; set; } = string.Empty;

    [ForeignKey(nameof(Author))]
    public int AuthorId { get; set; }

    public User Author { get; set; } = null!;

    [Required]
    public virtual List<Comments> CommentList { get; set; } = new();

    [Required]
    public virtual List<Likes> LikedList { get; set; } = new();
}
