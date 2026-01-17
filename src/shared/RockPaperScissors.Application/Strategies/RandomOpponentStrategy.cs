using RockPaperScissors.Application.Abstractions;
using RockPaperScissors.Domain.Enums;

namespace RockPaperScissors.Application.Strategies;

/// <summary>
/// Simple AI opponent that randomly selects Rock, Paper, or Scissors.
/// </summary>
public class RandomOpponentStrategy : IOpponentStrategy
{
    private readonly Random _random;

    public RandomOpponentStrategy()
    {
        _random = new Random();
    }

    /// <summary>
    /// Randomly selects one of the available moves.
    /// Uses enum reflection to support any number of moves dynamically.
    /// </summary>
    public Move GetMove()
    {
        // Get all possible moves from the enum
        var moves = Enum.GetValues<Move>();

        // Pick a random move from the available options
        var randomIndex = _random.Next(moves.Length);

        return moves[randomIndex];
    }
}
