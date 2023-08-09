using SocialMedia.Models;
using SocialMedia.Models.LikeListItem;
using SocialMedia.Models.Likes;

namespace SocialMedia.Services.Like;

public interface ILikeService
{
    Task<LikeListItem?> CreateLikeAsync(LikeService request);
    Task<IEnumerable<LikeListItem>> GetAllLikesAsync();
    Task<LikeDetail?> GetLikesByPostIdAsync(int PostId);
    Task<LikeDetail?> GetLikesByOwnerIdAsync(int OwnerId);
    Task<bool> UpdateLikesAsync(LikeUpdate Request);
}
