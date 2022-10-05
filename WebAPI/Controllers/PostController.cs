using Application.LogicInterfaces;
using Domain;
using Domain.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[ApiController]
[Route("[controller]")]

public class PostController : ControllerBase
{
    private readonly IPostLogic PostLogic;

    public PostController(IPostLogic postLogic)
    {
        PostLogic = postLogic;
    }

    [HttpPost]
    public async Task<ActionResult<Post>> CreateAsync(CreatePostDto post)
    {
        try
        {
            Post CreatedPost = await PostLogic.CreateAsync(post);
            return Created($"/posts/{CreatedPost.Id}", CreatedPost);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }
}