﻿
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SocialMedia.Data;

public class Post {
    [Key]
    public int Id { get; set; }

    [Required, MinLength(1), MaxLength(100)]
    public string Title { get; set; } = string.Empty;

    [Required, MinLength(1), MaxLength(800)]
    public string Text { get; set; } = string.Empty;

    [ForeignKey(nameof(Author))]
    public int AuthorId { get; set; }

    public User Author { get; set; } = null!;
    /* //requires further implimentation from other team members <- IS COMMENTED FOR TESTING
    public virtual List<Comment> CommentList { get; set; } = new();

    public virtual List<Like> LikedList { get; set; } = new();
    */
}
