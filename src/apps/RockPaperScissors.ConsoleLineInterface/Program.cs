using Microsoft.Extensions.DependencyInjection;
using RockPaperScissors.Application.Abstractions;
using RockPaperScissors.Application.Strategies;
using RockPaperScissors.Application.UseCases;

namespace RockPaperScissors.ConsoleLineInterface;

public class Program
{
    public static async Task Main(string[] args)
    {
        var services = new ServiceCollection();

        // Application layer
        services.AddSingleton<IOpponentStrategy, RandomOpponentStrategy>();
        services.AddTransient<PlayRoundUseCase>();

        // Presentation layer
        services.AddSingleton<ConsoleScoreTracker>();
        services.AddTransient<GameLoop>();

        await using var sp = services.BuildServiceProvider();
        var game = sp.GetRequiredService<GameLoop>();
        await game.StartAsync(CancellationToken.None);
    }
}