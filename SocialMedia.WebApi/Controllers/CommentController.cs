using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using SocialMedia.Services;
using SocialMedia.Models;


namespace SocialMedia.WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CommentController : ControllerBase
{
    private readonly ICommentService _commentService;

    public CommentController(ICommentService commentService)
    {
        _commentService = commentService;
    }

    // private readonly ApplicationDbContext _context;
    // public CommentController(ApplicationDbContext context)
    // {
    //     _context = context;
    // }
    
    [HttpGet]
    public async Task<IActionResult> GetAllComments()
    {
        var comments = await _commentService.GetAllCommentsAsync();
        return Ok(comments);
    }

    [HttpGet("{PostId:int}")]
    public async Task<IActionResult> GetCommentByPostId([FromRoute] int PostId)
    {
        var comment = await _commentService.GetCommentByPostIdAsync(PostId);

        if (comment is null)
        {
            return NotFound();
        }

        return Ok(comment);
    }
    [HttpGet("{PostId:int}")]
    public async Task<IActionResult> GetCommentByAuthorId([FromRoute] int AuthorId)
    {
        var comment = await _commentService.GetCommentByAuthorIdAsync(AuthorId);

        if (comment is null)
        {
            return NotFound();
        }

        return Ok(comment);
    }


    [HttpPost]
    public async Task<IActionResult> PostComment([FromBody] CommentCreate request)
    {
        if (ModelState.IsValid)
        {   /*
            _context.Comments.Add(request);
            await _context.SaveChangesAsync();
            */
            return Ok();
        }
        return BadRequest(ModelState);
    }

    // [HttpPut]
    // public async Task<IActionResult> PutComment([FromBody] Comment request)
    // {
    //     if (!ModelState.IsValid)
    //     {
    //         return BadRequest(ModelState);
    //     }

    //     Comment? comment = await _context.Comments.FindAsync(request.Id);
    //     if (comment is null)
    //     {
    //         return NotFound();
    //     }
    // }
}