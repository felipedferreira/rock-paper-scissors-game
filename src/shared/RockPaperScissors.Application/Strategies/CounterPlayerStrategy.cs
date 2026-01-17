using RockPaperScissors.Application.Abstractions;
using RockPaperScissors.Domain.Enums;

namespace RockPaperScissors.Application.Strategies;

/// <summary>
/// Advanced AI strategy that tries to counter the player's last move.
/// Assumes players tend to repeat or follow patterns.
/// Example: If player played Rock last time, AI plays Paper to counter.
/// </summary>
public class CounterPlayerStrategy : IOpponentStrategy
{
    private Move? _lastPlayerMove;

    /// <summary>
    /// Gets a move that counters the player's previous move.
    /// Falls back to random if no history exists.
    /// </summary>
    public Move GetMove()
    {
        if (_lastPlayerMove == null)
        {
            // No history yet, play randomly
            return GetRandomMove();
        }

        // Play the move that beats the player's last move
        return GetWinningMove(_lastPlayerMove.Value);
    }

    /// <summary>
    /// Updates the strategy with the player's most recent move.
    /// Call this after each round to enable pattern-based prediction.
    /// </summary>
    /// <param name="playerMove">The move the player just made</param>
    public void RecordPlayerMove(Move playerMove)
    {
        _lastPlayerMove = playerMove;
    }

    private static Move GetWinningMove(Move opponentMove)
    {
        return opponentMove switch
        {
            Move.Rock => Move.Paper,       // Paper beats Rock
            Move.Paper => Move.Scissors,   // Scissors beats Paper
            Move.Scissors => Move.Rock,    // Rock beats Scissors
            _ => throw new ArgumentOutOfRangeException(nameof(opponentMove))
        };
    }

    private static Move GetRandomMove()
    {
        var random = new Random();
        var moves = Enum.GetValues<Move>();
        return moves[random.Next(moves.Length)];
    }
}
