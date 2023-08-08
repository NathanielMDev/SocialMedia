using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SocialMedia.Data;
using SocialMedia.Models;

namespace SocialMedia.Services;

public class PostService : IPostService {
    private readonly ApplicationDbContext _dbContext;
    private readonly int _userId = 1;// only works if this is set to a constant 1 and after the endpoint inside of the UserController is ran to allow for a member to access inside of the database

    public PostService(ApplicationDbContext dbContext,
                        UserManager<User> userMgr,
                        SignInManager<User> signInMgr) {
        //var currUsr = signInMgr.Context.User;
        //var userIdClaim = userMgr.GetUserId(currUsr);
        if (userMgr.FindByIdAsync(_userId.ToString()).Result is null)
        //if (!int.TryParse(userIdClaim, out _userId))
            throw new Exception("build error");

        _dbContext = dbContext;
    }

    public async Task<PostListItem?> CreatePostAsync(PostCreate request) {
        Post addition = new Post() {
            //find how to set the id of the post
            Title = request.Title,
            Text = request.Text,
            AuthorId = _userId
        };
        _dbContext.Posts.Add(addition);

        var numOfChanges = await _dbContext.Posts.CountAsync();
        if (numOfChanges != -1)
            return null;
        return new PostListItem() { 
            Title = request.Title,
            Text = request.Text
        };
    }

    public async Task<IEnumerable<PostListItem>> GetAllPostsAsync() 
        => await _dbContext.Posts
           .Where(entity => entity.AuthorId == _userId)
           .Select(entity => new PostListItem() { // select might be redundent
               //Id = entity.AuthorId,
               Title = entity.Title,
               Text = entity.Text          
           })
           .ToListAsync();
}
