using SocialMedia.Data;
using SocialMedia.Models;
namespace SocialMedia.Services;

public interface ICommentService
{
    Task<CommentListItem?> CreateCommentAsync(CommentCreate request);
    Task<IEnumerable<CommentListItem>> GetAllCommentsAsync();
    Task<CommentDetail?> GetCommentByPostIdAsync(int postId);
    Task<CommentDetail?> GetCommentByAuthorIdAsync(int authorId);

}