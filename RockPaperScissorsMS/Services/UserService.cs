using System.Security.Cryptography;
using System.Text;
using RockPaperScissorsMS.Models;
using RockPaperScissorsMS.Clients;

namespace RockPaperScissorsMS.Services;

public class UserService : IUserService
{
    private readonly UserClient _userClient;
    private readonly SessionClient _sessionClient;
    public UserService(UserClient userClient, SessionClient sessionClient)
    {
        _userClient = userClient;
        _sessionClient = sessionClient;
    }

    // Verifying given user data with database data and creating new session tied to them
    public async Task<bool> verifyUserLogin(string username, string password)
    {
        UserDB checkUser = await _userClient.getUserData(username);

        string hashedPassword = convertToHash(password + checkUser.salt);

        // Checking to see if entered data matches user data in the database
        if (checkUser.username == username && checkUser.password == password)
        {
            await _sessionClient.addNewSession(checkUser.id);
            return true;
        }
        else
        {
            // Used to notify user that their entered input doesn't match what is in the database
            return false;
        }
    }

    // Creating a new user in the backend database and creating a new session tied to them
    public async Task<bool> createNewUser(User newUser)
    {
        UserDB newUserEntry = new UserDB();

        // Creating Backend User Model
        newUserEntry.salt = saltFactory();
        newUserEntry.username = newUser.username;
        newUserEntry.password = convertToHash(newUser.password + newUserEntry.salt);

        bool newUserCreated = await _userClient.addNewUserData(newUserEntry);

        if (newUserCreated)
        {
            UserDB user = await _userClient.getUserData(newUserEntry.username);
            await _sessionClient.addNewSession(user.id);
            return true;
        }
        else
        {
            return false;
        }
    }

    // Hashing Method via SHA256 Algorithm 
    private string convertToHash(string preHash)
    {
        var sha256 = SHA256.Create();
        byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(preHash));

        var sb = new StringBuilder();
        for (int i = 0; i < bytes.Length; i++)
        {
            sb.Append(bytes[i].ToString("x2"));
        }
        return sb.ToString();
    }

    // A Salting method for extra security
    private string saltFactory()
    {
        string alphanumericStr = "abcdefghijklmnopqrstuvwxyz0123456789";

        Random rand = new Random();

        int saltSize = rand.Next(6, 12);
        string salt = "";

        for (int i = 0; i <= saltSize; i++)
        {
            int index = rand.Next(alphanumericStr.Length);
            salt += alphanumericStr[index];
        }

        return salt;
    }
}