using SocialMedia.Models;
using SocialMedia.Models.LikeListItem;
using SocialMedia.Models.Likes;

namespace SocialMedia.Services.Like;

public interface ILikeService
{
    Task<LikeListItem?> CreateLikeAsync(LikeCreate request);
    Task<IEnumerable<LikeListItem>> GetAllLikesAsync();
    Task<LikeDetail?> GetLikesByPostIdAsync(int postId);
    Task<LikeDetail?> GetLikesByOwnerIdAsync(int ownerId);
    Task<bool> UpdateLikesAsync(LikeUpdate Request);
}
