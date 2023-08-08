namespace SocialMedia.Models.Comments;

public class CommentCreate 
{
    public int Id { get; set; }

    [Required, MinLength(1), MaxLength(256)]
    public string Text { get; set; } = string.Empty;

}