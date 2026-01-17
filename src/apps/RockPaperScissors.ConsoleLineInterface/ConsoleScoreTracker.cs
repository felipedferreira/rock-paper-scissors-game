using RockPaperScissors.Domain.Enums;

namespace RockPaperScissors.ConsoleLineInterface;

/// <summary>
/// Presentation-layer class to track and display scores for the console UI.
/// This is specific to the console application and not reusable for other presentations.
/// </summary>
public class ConsoleScoreTracker
{
    public int Wins { get; private set; }
    public int Losses { get; private set; }
    public int Ties { get; private set; }
    public int RoundsPlayed => Losses + Ties + Wins;

    /// <summary>
    /// Updates the score based on the round result from the user's perspective.
    /// </summary>
    /// <param name="userResult">The game result from the user's perspective</param>
    public void UpdateScore(GameResult userResult)
    {
        switch (userResult)
        {
            case GameResult.Winner:
                Wins++;
                break;
            case GameResult.Loser:
                Losses++;
                break;
            case GameResult.Draw:
                Ties++;
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(userResult), userResult, null);
        }
    }

    public void Reset()
    {
        Wins = 0;
        Losses = 0;
        Ties = 0;
    }

    /// <summary>
    /// Gets a friendly message about the current game standing.
    /// </summary>
    public string GetStandingMessage()
    {
        if (Wins > Losses)
        {
            return "[green]You're[/] in the lead!";
        }

        if (Losses > Wins)
        {
            return "The [red]computer[/] is winning!";
        }

        return "It's [yellow]tied[/]!";
    }
}
