using SocialMedia.Models;

namespace SocialMedia.Services;

public interface IUserService {
    Task<bool> CreateUserAsync(UserCreate request);
}
