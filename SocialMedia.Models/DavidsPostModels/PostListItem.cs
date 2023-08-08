using System.ComponentModel.DataAnnotations;

namespace SocialMedia.Models;

public class PostListItem {
/*    [Required]
    public int Id { get; set; }*/
    [Required]
    [MinLength(1)]
    [MaxLength(100)]
    public string Title { get; set; } = string.Empty;
    [Required]
    [MaxLength(800)]
    public string Text { get; set; } = string.Empty;

}
