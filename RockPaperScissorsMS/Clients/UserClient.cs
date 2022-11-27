using Microsoft.Extensions.Options;
using System.Text.Json;
using System.Text;
using RockPaperScissorsMS.Models;
using RockPaperScissorsMS.Configurations;

namespace RockPaperScissorsMS.Clients;

public class UserClient
{
    private readonly UrlConfiguration _urlConfig;
    private readonly HttpClient _client;
    public UserClient(IOptions<UrlConfiguration> urlConfig, HttpClient client)
    {
        _client = client;
        _urlConfig = urlConfig.Value;
    }

    public async Task<UserDB> getUserData(string username)
    {
        HttpResponseMessage response = await _client.GetAsync(_urlConfig.UserUrl + $"/Verify/{username}");
        var json = await response.Content.ReadAsStringAsync();
        Console.WriteLine(response);
        Console.WriteLine(json);
        return JsonSerializer.Deserialize<UserDB>(json) ?? new UserDB();
    }

    public async Task<bool> addNewUserData(UserDB newUser)
    {
        var serializedUser = JsonSerializer.Serialize(newUser);
        StringContent content = new StringContent(serializedUser, UnicodeEncoding.UTF8, "application/json");
        HttpResponseMessage response = await _client.PostAsync(_urlConfig.UserUrl + "/NewUser", content);
        return JsonSerializer.Deserialize<bool>(await response.Content.ReadAsStringAsync());
    }
}