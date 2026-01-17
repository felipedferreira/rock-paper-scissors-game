using RockPaperScissors.Domain.Enums;

namespace RockPaperScissors.Domain;

public record Round
{
    public Round(Move player1, Move player2)
    {
        Player1 = player1;
        Player2 = player2;
        Result = GetResult(Player1, Player2);
    }
    
    public Move Player1 { get; }
    public Move Player2 { get; }
    public GameResult Result { get; }
    
    /// <summary>
    /// Responsible for determining the result of a game given the moves of both players.
    /// </summary>
    /// <param name="player1"></param>
    /// <param name="player2"></param>
    /// <returns></returns>
    public static GameResult GetResult(Move player1, Move player2)
    {
        if (player1 == player2)
        {
            return GameResult.Draw;
        }
        
        if(GetWinningMove(player1) == player2)
        {
            return GameResult.Loser;
        }

        return GameResult.Winner;
    }
    
    /// <summary>
    /// Responsible for determining which move wins against the given move.
    /// </summary>
    /// <param name="move"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentOutOfRangeException"></exception>
    private static Move GetWinningMove(Move move)
    {
        return move switch
        {
            Move.Rock => Move.Paper,
            Move.Paper => Move.Scissors,
            Move.Scissors => Move.Rock,
            _ => throw new ArgumentOutOfRangeException(nameof(move), move, null)
        };
    }
}