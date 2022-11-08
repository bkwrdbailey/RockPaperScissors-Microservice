using RockPaperScissorsMS.Models;

namespace RockPaperScissorsMS.Services;
public interface IUserService
{
    Task<UserSession> verifyUserLogin(string username, string password);
    Task<UserSession> createNewUser(User newUser);
}