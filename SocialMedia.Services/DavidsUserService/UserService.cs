using Microsoft.AspNetCore.Identity;
using SocialMedia.Data;
using SocialMedia.Models;

namespace SocialMedia.Services;

public class UserService : IUserService {
    private readonly ApplicationDbContext _dbContext;
    private readonly UserManager<User> _userManager;

    public UserService(ApplicationDbContext dbContext, UserManager<User> userMgr) {
        _dbContext = dbContext;
        _userManager = userMgr;
    }

    public async Task<bool> CreateUserAsync(UserCreate request) { 

        User addition = new() {
            FirstName = request.FirstName,
            LastName = request.LastName,
            //Password = request.Password,
            Email = request.Email,
            UserName = request.Email,
            
        };

        IdentityResult res = await _userManager.CreateAsync(addition, request.Password);
        Console.WriteLine(res.Errors.First().Description);
        return res.Succeeded;
    }
}
