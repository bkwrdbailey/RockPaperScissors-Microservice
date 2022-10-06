using Microsoft.AspNetCore.Mvc;
using RockPaperScissorsMS.Models;
using RockPaperScissorsMS.Services;

namespace RockPaperScissorsMS.Controllers;

[ApiController]
public class GameController : ControllerBase
{
    private readonly IGameService _service;

    public GameController(IGameService service)
    {
        _service = service;
    }

    // [HttpPut("game/nextstate")]
    // public async Task<GameState> updatePlayerGameState([FromBody] GameState currGameState)
    // {
    //     return await _service.nextPlayerGameState(currGameState);
    // }

    [HttpPut("game/computer/nextstate")]
    public async Task<GameState> updateComputerGameState([FromBody] GameState currGameState)
    {
        return await _service.nextComputerGameState(currGameState);
    }
}
