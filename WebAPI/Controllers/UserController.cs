using Application.LogicInterfaces;
using Domain;
using Domain.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{

    private readonly IUserLogic UserLogic;
    public UserController(IUserLogic userLogic)
    {
        UserLogic = userLogic;
    }

    [HttpPost]
    public async Task<ActionResult<User>> CreateAsync(CreateUserDto user)
    {
        try
        {
            User User = await UserLogic.CreateAsync(user);
            return Created($"/users/{User.Id}", User);
        }
        catch (Exception e)
        {
            Console.WriteLine(e); 
            return StatusCode(500,e.Message);
        }
    } 
}