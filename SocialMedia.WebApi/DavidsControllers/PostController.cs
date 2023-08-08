using Microsoft.AspNetCore.Mvc;

using SocialMedia.Models;
using SocialMedia.Services;

namespace SocialMedia.WebApi.Controllers;

[Route("Api/[controller]")]
[ApiController]
public class PostController : ControllerBase {
    private readonly IPostService _postService;

    public PostController(IPostService postService) {
        _postService = postService;
    }
    
    [HttpPost]
    public async Task<IActionResult> CreatePostAsync([FromBody] PostCreate request) {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var makeDatPost = await _postService.CreatePostAsync(request);
        return (makeDatPost is null) ? BadRequest(makeDatPost) : Ok(makeDatPost);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllPostsAsync() {
        var allaDemPosts = await _postService.GetAllPostsAsync();
        return Ok(allaDemPosts);
    }
/*
    [HttpGet("{postId:int}")]
    public async Task<IActionResult> GetPostByIdAsync([FromRoute] int PostId) { 
        Post? post = await _postService.GetPostByIdAsync(PostId);
        return (post is null)? NotFound(): Ok(post);
    }

    [HttpPut]
    public async Task<IActionResult> UpdatePostAsync([FromBody] PostUpdate request) { 
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        return await _postService.UpdatePostAsync(request)? Ok("Updated"): BadRequest("Failure updating");
    }

    [HttpDelete("{noteId:int}")]
    public async Task<IActionResult> DeletePostAsync([FromRoute] int PostId)
        => await _postService.DeletePostAsync(PostId) ? Ok("deleted") : NotFound("note not deleted");
    */
}
