using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace SocialMedia.Models;

public class CommentCreate 
{
    public int Id { get; set; }

    [Required, MinLength(1), MaxLength(256)]
    public string Text { get; set; } = string.Empty;

}