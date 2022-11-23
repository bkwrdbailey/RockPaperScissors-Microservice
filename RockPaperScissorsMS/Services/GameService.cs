using RockPaperScissorsMS.Models;
using RockPaperScissorsMS.Clients;

namespace RockPaperScissorsMS.Services;

public class GameService : IGameService
{
    public GameService()
    {

    }

    // public async Task<GameState> nextPlayerGameState(GameState currGameState)
    // {
        
    //     return;
    // }

    public async Task<GameState> nextComputerGameState(GameState currGameState)
    {
        Random computerTurn = new Random();
        int computerChoice = computerTurn.Next(1, 3);

        switch (computerChoice)
        {
            case 1:
                currGameState.playerTwoChoice = "rock";
                break;

            case 2:
                currGameState.playerTwoChoice = "paper";
                break;

            case 3:
                currGameState.playerTwoChoice = "scissors";
                break;

            default:
                break;
        }

        if (currGameState.playerOneChoice == "rock" && currGameState.playerTwoChoice == "scissors")
        {
            currGameState.winner = currGameState.playerOne;
        }
        else if (currGameState.playerOneChoice == "paper" && currGameState.playerTwoChoice == "rock")
        {
            currGameState.winner = currGameState.playerOne;
        }
        else if (currGameState.playerOneChoice == "scissors" && currGameState.playerTwoChoice == "paper")
        {
            currGameState.winner = currGameState.playerOne;
        }
        else if (currGameState.playerTwoChoice == "paper" && currGameState.playerOneChoice == "rock")
        {
            currGameState.winner = currGameState.playerTwo;
        }
        else if (currGameState.playerTwoChoice == "scissors" && currGameState.playerOneChoice == "paper")
        {
            currGameState.winner = currGameState.playerTwo;
        }
        else if (currGameState.playerTwoChoice == "rock" && currGameState.playerOneChoice == "scissors")
        {
            currGameState.winner = currGameState.playerTwo;
        }
        else
        {
            currGameState.winner = "draw";
        }

        return currGameState;
    }
}