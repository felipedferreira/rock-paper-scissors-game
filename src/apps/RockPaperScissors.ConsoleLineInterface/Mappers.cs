using RockPaperScissors.Domain.Enums;

namespace RockPaperScissors.ConsoleLineInterface;

public static class Mappers
{
    public static Move ToMove(this string userSelection)
    {
        return userSelection switch
        {
            Constants.RockSelection => Move.Rock,
            Constants.PaperSelection => Move.Paper,
            Constants.ScissorsSelection => Move.Scissors,
            _ => throw new ArgumentOutOfRangeException(nameof(userSelection), userSelection, "Invalid user selection"),
        };
    }

    public static string ToEmoji(this Move move)
    {
        return move switch
        {
            Move.Rock => "🪨",
            Move.Paper => "📄",
            Move.Scissors => "✂️",
            _ => throw new ArgumentOutOfRangeException(nameof(move), move, "Invalid move"),
        };
    }
}