using SocialMedia.Models;
using SocialMedia.Data;

namespace SocialMedia.Services;

public class CommentService : ICommentService
{
    private readonly ApplicationDbContext _context;
    public CommentService(ApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<CommentListItem> CreateCommentAsync(CommentCreate request)
    {
        Comment comment = new()
        {
            Id = request.Id,
            Text = request.Text
        };

        _context.Comment.Add(comment);
        var numberOfChanges = await _context.SaveChangesAsync();

        if (numberOfChanges != 1)
            return null;

        CommentListItem response new()
        {
            Id = comment.Id,
            Text = comment.Text
        };

        return response;
    }

    public async Task<CommentDetail?> GetCommentByPostIdAsync(int postId)
    {
        CommentService comment = await _context.Comment.FindAsync(postId);
        if (comment is null)
        return null;
    }

    public async Task<CommentDetail?> GetCommentByAuthorIdAsync(int authorId)
    {
        CommentService comment = await _context.Comment.FindAsync(authorId);
        if (comment is null)
        return null;
    }
}