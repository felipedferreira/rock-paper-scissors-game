using RockPaperScissors.Application.Abstractions;
using RockPaperScissors.Domain.Enums;

namespace RockPaperScissors.Application.Strategies;

/// <summary>
/// Simple test strategy that always returns Rock.
/// Useful for testing and debugging.
/// </summary>
public class AlwaysRockStrategy : IOpponentStrategy
{
    public Move GetMove()
    {
        return Move.Rock;
    }
}
