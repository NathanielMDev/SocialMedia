using SocialMedia.Data;
using SocialMedia.Services;
using SocialMedia.Models;
namespace SocialMedia.Services.Comment;

internal interface ICommentService
{
    Task<Post?> CreateCommentAsync(CommentCreate request);
    Task<Get> GetCommentByPostIdAsync(int PostId);
    Task<Get> GetCommentByCommentAuthorIdAsync(int AuthorId)
    Task<bool> UpdateCommentAsync(CommentUpdate Request);
    Task<bool> DeleteCommentAsync(int id);

}