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

        _context.Comments.Add(comment);
        var numberOfChanges = await _context.SaveChangesAsync();

        if (numberOfChanges != 1)
            return null;

        CommentListItem response = new()
        {
            Id = comment.Id,
            Text = comment.Text
        };

        return response;
    }

    public async Task<CommentDetail?> GetCommentByPostIdAsync(int postId)
    {
        Comment comment = await _context.Comments.FindAsync(postId);
        if (comment is null)
            return null;

        return new CommentDetail()
        {
            Id = comment.Id,
            Text = comment.Text
        };
    }

    public async Task<CommentDetail?> GetCommentByAuthorIdAsync(int authorId)
    {
        Comment comment = await _context.Comments.FindAsync(authorId);
        if (comment is null)
            return null;

        return new CommentDetail()
        {
            Id = comment.Id,
            Text = comment.Text
        };
    }

    public async Task<IEnumerable<CommentListItem>> GetAllCommentsAsync()
    {
        return new List<CommentListItem>();
    }
}