using Microsoft.AspNetCore.Mvc;
using RockPaperScissorsMS.Models;
using RockPaperScissorsMS.Services;

namespace RockPaperScissorsMS.Controllers;

[ApiController]
public class SessionController : ControllerBase
{
    private readonly ISessionService _service;
    public SessionController(ISessionService service)
    {
        _service = service;
    }

    [HttpPut("Session/Status")]
    public async Task<bool> checkSessionStatus([FromBody] string username)
    {
        return await _service.checkSessionStatus(username);
    }

    [HttpDelete("Session/Removal/{userId}")]
    public async Task removeASession(int userId)
    {
        await _service.removeASession(userId);
    }
}