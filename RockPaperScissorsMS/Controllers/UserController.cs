using Microsoft.AspNetCore.Mvc;
using RockPaperScissorsMS.Models;
using RockPaperScissorsMS.Services;

namespace RockPaperScissorsMS.Controllers;

[ApiController]
public class UserController : ControllerBase
{
    private readonly IUserService _service;
    public UserController(IUserService service)
    {
        _service = service;
    }

    // [HttpGet("user/login?name={username}&pass={password}")]
    // public async Task<User> getUser(string username, string password)
    // {

    // }

    // [HttpPost("user/register")]
    // public async Task createUser([FromBody] User newUser)
    // {

    // }
}
