
namespace RockPaperScissorsMS.Models;

public class UserDB
{
    // Unique identifier for user records (PK)
    public int id { get; set; }
    // Username attached to a user account
    public string? username { get; set; }
    // Hashed password attached to a user account
    public string? password { get; set; }
    // Salt used for the hashing of the password
    public string? salt { get; set; }
}