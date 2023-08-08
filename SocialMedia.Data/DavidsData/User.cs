using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace SocialMedia.Data;

public class User : IdentityUser<int> {
    /* // i think this overrides something and is unnessesary 
    [Required, EmailAddress, MaxLength(100)]
    public string Email { get; set; } = string.Empty;
    */
    [Required, MaxLength(100)]
    public string Password { get; set; } = string.Empty;

    [MaxLength(50)]
    public string? FirstName { get; set; }

    [MaxLength(50)]
    public string? LastName { get; set; }
}
