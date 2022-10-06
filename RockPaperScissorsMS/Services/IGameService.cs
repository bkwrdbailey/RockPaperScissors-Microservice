using RockPaperScissorsMS.Models;

namespace RockPaperScissorsMS.Services;
public interface IGameService
{
    // Task<GameState> nextPlayerGameState(GameState currGameState);
    Task<GameState> nextComputerGameState(GameState currGameState);
}