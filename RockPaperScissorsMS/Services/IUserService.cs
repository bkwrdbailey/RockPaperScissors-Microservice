using RockPaperScissorsMS.Models;

namespace RockPaperScissorsMS.Services;
public interface IUserService
{
    Task<bool> verifyUserLogin(string username, string password);
    Task<bool> createNewUser(User newUser);
}