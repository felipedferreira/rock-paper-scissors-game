using RockPaperScissors.Application.Abstractions;
using RockPaperScissors.Application.UseCases;
using RockPaperScissors.Domain;
using RockPaperScissors.Domain.Enums;
using Spectre.Console;

namespace RockPaperScissors.ConsoleLineInterface;

public class GameLoop
{
    private readonly PlayRoundUseCase _useCase;
    private readonly ConsoleScoreTracker _scoreTracker;
    private readonly IOpponentStrategy _opponentStrategy;
    private readonly TimeSpan _standardDelay = TimeSpan.FromSeconds(3);
    public GameLoop(PlayRoundUseCase useCase, ConsoleScoreTracker scoreTracker, IOpponentStrategy opponentStrategy)
    {
        _useCase = useCase;
        _scoreTracker = scoreTracker;
        _opponentStrategy = opponentStrategy;
    }

    public async Task StartAsync(CancellationToken cancellationToken = default)
    {
        await DisplayIntroAsync(cancellationToken);
        while (!cancellationToken.IsCancellationRequested)
        {
            Console.Clear();
            DisplayScore();
            // Get user selection
            var userSelection = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .Title("[Orange1]Make your selection[/]:")
                    .AddChoices(
                        Constants.RockSelection,
                        Constants.PaperSelection,
                        Constants.ScissorsSelection))
                .ToMove();

            // Execute round
            var round = _useCase.Execute(userSelection, _opponentStrategy);
            DisplayRoundResult(round);

            // Update score
            _scoreTracker.UpdateScore(round.Result);

            await Task.Delay(_standardDelay, cancellationToken);
        }

        Console.Clear();
        DisplayScore();
        AnsiConsole.MarkupLine("[red]Game has ended.[/]");
    }

    private async Task DisplayIntroAsync(CancellationToken cancellationToken)
    {
        var introText = new FigletText("R * P * S")
            {
                Justification = Justify.Center,
                Pad = false,
            }
            .Color(Color.Orange1);
        AnsiConsole.Write(introText);
        await Task.Delay(_standardDelay, cancellationToken);
    }

    private void DisplayScore()
    {
        var standingMessage = _scoreTracker.GetStandingMessage();
        var panel = new Panel($"[green]You: {_scoreTracker.Wins}[/] | [red]Computer: {_scoreTracker.Losses}[/] | [yellow]Ties: {_scoreTracker.Ties}[/] | Rounds: {_scoreTracker.RoundsPlayed} | {standingMessage}")
            .Padding(2, 2)
            .RoundedBorder()
            .Header("[blue]Score[/]");
        AnsiConsole.Write(Align.Center(panel));
    }

    private void DisplayRoundResult(Round round)
    {
        var tableWidth = 30;
        var table = new Table()
            .RoundedBorder()
            .AddColumn("You", col => col.Centered().PadLeft(2).PadRight(2))
            .AddColumn("Computer", col => col.Centered().PadLeft(2).PadRight(2))// .Width(tableWidth)
            .AddColumn("Result", col => col.Centered().PadLeft(2).PadRight(2));

        var resultText = round.Result switch
        {
            GameResult.Winner => "[green]🎉 - You're the Winner[/]",
            GameResult.Loser => "[red]😭 - You Lost[/]",
            GameResult.Draw => "[yellow]😐 - Draw[/]",
            _ => "Unknown"
        };

        table.AddRow(
            $"[green]{round.Player1.ToEmoji()}[/]",
            $"[red]{round.Player2.ToEmoji()}[/]",
            resultText
        );

        AnsiConsole.Write(table);
    }
}