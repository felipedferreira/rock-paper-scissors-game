using RockPaperScissors.Domain.Enums;

namespace RockPaperScissors.Application.Abstractions;

/// <summary>
/// Abstraction for different opponent move selection strategies.
/// Implementations can provide: random AI, smart AI, human input, etc.
/// </summary>
public interface IOpponentStrategy
{
    /// <summary>
    /// Gets the opponent's move for the current round.
    /// </summary>
    /// <returns>The move selected by the opponent</returns>
    Move GetMove();
}
