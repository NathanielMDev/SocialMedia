using SocialMedia.Data;
using SocialMedia.Models;
using Microsoft.EntityFrameworkCore;
using SocialMedia.Models.LikeListItem;
using SocialMedia.Data.Likes;
using SocialMedia.Models.Likes;

namespace SocialMedia.Services.Like;

public class LikeService : ILikeService
{
    private readonly ApplicationDbContext _dbContext;
    private readonly int _userId;
    
    
    public LikeService(UserManager<User> userManager,
                       SignInManager<User> signInManager,
                       ApplicationDbContext dbContext)
    {
        var currentUser = signInManager.Context.User;
        var userIdClaim = userManager.GetUserId(currentUser);
        
        _dbContext = dbContext;
    }

    public async Task<IEnumerable<LikeListItem>> GetAllLikesAsync()
    {
        List<LikeListItem> likes = await _dbContext.Likes
        .Where(entity => entity.OwnerId == _userId)
        .Select(entity => new LikeListItem
        {
            PostId = entity.PostId,
            Id = entity.Id
        })
        .ToListAsync();

        return likes;
    }

    public async Task<LikeListItem?> CreateLikeAsync(LikeCreate request)
    {
        Likes entity = new()
        {
            OwnerId = _userId,
            PostId = request.PostId,
        };

        _dbContext.Likes.Add(entity);
        var numberOfChanges = await _dbContext.SaveChangesAsync();

        if (numberOfChanges != 1)
            return null;

        LikeListItem response = new()
        {
            Id = entity.Id
        };
        return response;
    }

    public async Task<LikeDetail?> GetLikeByPostIdAsync(int postId)
    {
        Likes? entity = await _dbContext.Likes
            .FirstOrDefaultAsync(e =>
            e.Id == postId && e.OwnerId == _userId);

        return entity is null ? null : new LikeDetail
        {
            Id = entity.Id,
            UserId = entity.UserId
        };
    }

    public async Task<LikeDetail?> GetLikeByOwnerIdAsync(int ownerId)
    {
        Likes? entity = await _dbContext.Likes
            .FirstOrDefaultAsync(e =>
            e.Id == ownerId && e.OwnerId == _userId);

        return entity is null ? null : new LikeDetail
        {
            Id = entity.Id,
            UserId = entity.UserId
        };
    }

    public async Task<bool> UpdateLikeAsync(LikeUpdate request)
    {
        Likes? entity = await _dbContext.Likes.FindAsync(request.Id);
        if (entity?.OwnerId != _userId)
            return false;
        
        entity.PostId = request.PostId;

        int numberOfChanges = await _dbContext.SaveChangesAsync();

        return numberOfChanges == 1;
    }

   
}

