using RockPaperScissors.Application.Abstractions;
using RockPaperScissors.Domain;
using RockPaperScissors.Domain.Enums;

namespace RockPaperScissors.Application.UseCases;

/// <summary>
/// Use case for playing a single round of Rock-Paper-Scissors.
/// Coordinates getting moves from both players and creating a Round.
/// </summary>
public class PlayRoundUseCase
{
    /// <summary>
    /// Executes a round of the game.
    /// </summary>
    /// <param name="playerMove">The move made by the player</param>
    /// <param name="opponentStrategy">Strategy for determining the opponent's move</param>
    /// <returns>A Round containing both moves and the calculated result</returns>
    public Round Execute(Move playerMove, IOpponentStrategy opponentStrategy)
    {
        // Get opponent's move using the provided strategy
        // This abstraction allows for different implementations:
        // 1. RandomOpponentStrategy - randomly selects rock, paper, scissors
        // 2. CounterPlayerStrategy - tries to counter the player's patterns
        // 3. HumanOpponentStrategy - gets move from another player (future)
        // 4. Strategy can change between rounds based on difficulty/mode
        var opponentMove = opponentStrategy.GetMove();

        // Create Round - the domain object automatically calculates the winner
        // Result is from player1's (the human player's) perspective
        return new Round(playerMove, opponentMove);
    }
}