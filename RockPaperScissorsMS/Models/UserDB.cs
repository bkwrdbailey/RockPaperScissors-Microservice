
namespace RockPaperScissorsMS.Models;

public class UserDB
{
    public int id { get; set; } = 0;
    public string username { get; set; } = "";
    public string password { get; set; } = "";
    public string salt { get; set; } = "";
}