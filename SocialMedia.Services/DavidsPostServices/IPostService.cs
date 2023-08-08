using SocialMedia.Models;

namespace SocialMedia.Services;

public interface IPostService {
    Task<PostListItem?> CreatePostAsync(PostCreate request);
    Task<IEnumerable<PostListItem>> GetAllPostsAsync();
    /*  // further implimentation
    Task<Post?> GetPostByIdAsync(int postId);
    Task<bool> UpdatePostAsync(PostUpdate request); //get post id somehow
    Task<bool> DeletePostAsync(int id);
    */
}
