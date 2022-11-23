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

    [HttpGet("user/login?name={username}&pass={password}")]
    public async Task<bool> getUser(string username, string password)
    {
        return await _service.verifyUserLogin(username, password);
    }

    [HttpPost("user/register")]
    public async Task<bool> createUser([FromBody] User newUser)
    {
        return await _service.createNewUser(newUser);
    }
}
