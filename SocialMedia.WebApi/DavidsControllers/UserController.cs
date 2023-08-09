using Microsoft.AspNetCore.Mvc;
using SocialMedia.Models;
using SocialMedia.Services;

namespace SocialMedia.WebApi.Controllers;

[Route("Api/[controller]")]
[ApiController]
public class UserController : Controller {
    private readonly IUserService _userService;

    public UserController(IUserService userService) {
        _userService = userService;
    }

    [HttpPost("Register")]
    public async Task<IActionResult> CreateUserAsync([FromBody] UserCreate request) {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var makeDatUser = await _userService.CreateUserAsync(request);
        return (makeDatUser == false) ? BadRequest(makeDatUser) : Ok(makeDatUser);
    }
}
