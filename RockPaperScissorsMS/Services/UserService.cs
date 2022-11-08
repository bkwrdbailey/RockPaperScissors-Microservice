using System.Security.Cryptography;
using System.Text;
using RockPaperScissorsMS.Models;
using RockPaperScissorsMS.Clients;

namespace RockPaperScissorsMS.Services;

public class UserService : IUserService
{
    private readonly UserClient _client;
    public UserService(UserClient client)
    {
        _client = client;
    }

    public async Task<UserSession> verifyUserLogin(string username, string password)
    {
        UserSession currSession = new UserSession();
        UserDB checkUser = await _client.getUserData(username);

        string hashedPassword = convertToHash(password + checkUser.salt);

        // Checking to see if entered data matches user data in the database
        if (checkUser.username == username && checkUser.password == password)
        {
            // Need to Attach a JWT Token to signed in user
            currSession.AuthenticUser = true;
            return currSession;
        }
        else
        {
            // Used to notify user that their entered input doesn't match what is in the database
            currSession.AuthenticUser = false;
            return currSession;
        }
    }

    public async Task<UserSession> createNewUser(User newUser)
    {
        UserSession currSession = new UserSession();
        UserDB newUserEntry = new UserDB();

        // Creating Backend User Model
        newUserEntry.salt = saltFactory();
        newUserEntry.username = newUser.username;
        newUserEntry.password = convertToHash(newUser.password + newUserEntry.salt);

        currSession.AuthenticUser = await _client.addNewUserData(newUserEntry);

        return currSession;
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

    // A JWT Generator to attach to user after successful signin
    private void javaWebTokenGenerator()
    {

    }
}