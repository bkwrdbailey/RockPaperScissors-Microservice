namespace RockPaperScissorsMS.Models;
public class GameState
{
    public string? playerOne { get; set; }
    public string? playerOneChoice { get; set; }
    public string? playerTwo { get; set; }
    public string? playerTwoChoice { get; set; }
    public int rounds { get; set; }
    public string? winner { get; set; }
}