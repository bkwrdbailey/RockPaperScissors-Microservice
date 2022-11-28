using Microsoft.Extensions.Options;
using System.Text.Json;
using System.Text;
using RockPaperScissorsMS.Models;
using RockPaperScissorsMS.Configurations;

namespace RockPaperScissorsMS.Clients;

public class SessionClient
{
    private readonly UrlConfiguration _urlConfig;
    private readonly HttpClient _client;
    public SessionClient(IOptions<UrlConfiguration> urlConfig, HttpClient client)
    {
        _client = client;
        _urlConfig = urlConfig.Value;
    }

    public async Task<bool> checkIfSessionIsValid(int userId)
    {
        HttpResponseMessage response = await _client.GetAsync(_urlConfig.SessionUrl + $"/Validate/{userId}");
        var json = await response.Content.ReadAsStringAsync();
        return JsonSerializer.Deserialize<bool>(json);
    }

    public async Task addNewSession(int userId)
    {
        var serializedId = JsonSerializer.Serialize(userId);
        StringContent content = new StringContent(serializedId, UnicodeEncoding.UTF8, "application/json");
        HttpResponseMessage response = await _client.PostAsync(_urlConfig.SessionUrl + "/Create", content);
    }
}