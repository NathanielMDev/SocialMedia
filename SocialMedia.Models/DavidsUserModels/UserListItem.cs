
using System.ComponentModel.DataAnnotations;

namespace SocialMedia.Models;

public class UserListItem {
    [Required, MaxLength(100)]
    public string Password { get; set; } = string.Empty;

    [MaxLength(50)]
    public string FirstName { get; set; } = string.Empty;

    [MaxLength(50)]
    public string? LastName { get; set; } = string.Empty;
}
