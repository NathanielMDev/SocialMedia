
using System.ComponentModel.DataAnnotations;

namespace SocialMedia.Models;

public class UserCreate { 
    [Required, MaxLength(100)]
    public string Password { get; set; } = string.Empty;

    [MaxLength(50)]
    public string FirstName { get; set; } = string.Empty;

    [MaxLength(50)]
    public string LastName { get; set; } = string.Empty;

    [Required, EmailAddress, MaxLength(100)]
    public string Email { get; set; } = string.Empty;
}
