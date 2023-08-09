using SocialMedia.Models.;
using Microsoft.AspNetCore.Mvc;
using SocialMedia.Services.Like;
using SocialMedia.Models.Likes;

namespace SocialMedia.WebApi.Controller;

[Route("Api/[controller]")]
[ApiController]
public class LikeController : ControllerBase
{
    private readonly ILikeService _likeService;
    public LikeController(ILikeService likeService)
    {
        _likeService = likeService;
    }

    [HttpPost]
    public async Task<IActionResult> CreateLikeAsync([FromBody] LikeCreate request)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var response = await _likeService.CreateLikeAsync(request);
        if (response is not null)
            return Ok(response);
        
        return BadRequest(response);
    }

    [HttpGet("{postId:int}")]
    public async Task<IActionResult> GetLikesByPostId([FromRoute] int postId)
    {
        LikeDetail? detail = await _likeService.GetLikesByPostIdAsync(postId);
        
        return detail is not null
            ? Ok(detail)
            : NotFound();
        
    }

    [HttpGet("ownerId:int")]
    public async Task<IActionResult> GetLikesByOwnerId([FromRoute] int ownerId)
    {
        LikeDetail? detail = await _likeService.GetLikesByOwnerIdAsync(ownerId);

        return detail is not null
            ? Ok(detail)
            : NotFound();
    }

    [HttpPut]
    public async Task<IActionResult> UpdateLikeById([FromBody] LikeUpdate request)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        return await _likeService.UpdateLikesAsync(request)
            ? Ok("Like updated succesfully.")
            : BadRequest("Like could not be updated.");
    }
}