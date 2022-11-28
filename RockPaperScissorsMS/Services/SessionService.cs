using RockPaperScissorsMS.Models;
using RockPaperScissorsMS.Clients;

namespace RockPaperScissorsMS.Services;

public class SessionService : ISessionService
{
    private readonly SessionClient _sessionClient;
    private readonly UserClient _userClient;
    public SessionService(SessionClient sessionClient, UserClient userClient)
    {
        _sessionClient = sessionClient;
        _userClient = userClient;
    }

    // Check if the session has not expired yet
    public async Task<bool> checkSessionStatus(string username)
    {
        UserDB checkUser = await _userClient.getUserData(username);
        return await _sessionClient.checkIfSessionIsValid(checkUser.id);
    }

    public async Task removeASession(int userId)
    {
        await _sessionClient.deleteASession(userId);
    }
}