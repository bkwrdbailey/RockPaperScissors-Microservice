using RockPaperScissorsMS.Models;

namespace RockPaperScissorsMS.Services;

public interface ISessionService
{
    Task<bool> checkSessionStatus(string username);
    Task removeASession(int userId);
}