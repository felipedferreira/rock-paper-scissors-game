# Rock Paper Scissors Game

A console-based Rock-Paper-Scissors game built with .NET 10.0 and Clean Architecture principles. This project features a beautiful terminal UI powered by Spectre.Console and multiple AI opponent strategies.

## Features

- Interactive console interface with colorful ASCII art
- Multiple AI opponent strategies:
  - Random moves
  - Pattern-based counter strategy
  - Always Rock strategy (for testing)
- Real-time score tracking
- Round history
- Clean Architecture design with separation of concerns
- Dependency injection

## Project Structure

```
src/
├── apps/
│   └── RockPaperScissors.ConsoleLineInterface/  # Presentation layer
│       ├── Program.cs                           # Entry point & DI setup
│       ├── GameLoop.cs                          # Main game loop
│       ├── ConsoleScoreTracker.cs               # Score management
│       ├── Mappers.cs                           # UI mapping utilities
│       └── Constants.cs                         # UI constants
└── shared/
    ├── RockPaperScissors.Application/           # Application layer
    │   ├── UseCases/
    │   │   └── PlayRoundUseCase.cs              # Game round logic
    │   ├── Strategies/
    │   │   ├── RandomOpponentStrategy.cs        # Random AI
    │   │   ├── CounterPlayerStrategy.cs         # Pattern-matching AI
    │   │   └── AlwaysRockStrategy.cs            # Simple AI
    │   └── Abstractions/
    │       └── IOpponentStrategy.cs             # Strategy interface
    └── RockPaperScissors.Domain/                # Domain layer
        ├── Round.cs                             # Core game logic
        └── Enums/
            ├── Move.cs                          # Rock/Paper/Scissors
            └── GameResult.cs                    # Win/Lose/Draw
```

## Prerequisites

- [.NET 10.0 SDK](https://dotnet.microsoft.com/download/dotnet/10.0) or later
- A terminal that supports ANSI color codes (Windows Terminal, iTerm2, or similar)

## Getting Started

### Clone the Repository

```bash
git clone https://github.com/yourusername/rock-paper-scissors-game.git
cd rock-paper-scissors-game
```

### Build the Project

```bash
dotnet build
```

### Run the Game

```bash
dotnet run --project src/apps/RockPaperScissors.ConsoleLineInterface/RockPaperScissors.ConsoleLineInterface.csproj
```

Or navigate to the project directory:

```bash
cd src/apps/RockPaperScissors.ConsoleLineInterface
dotnet run
```

## How to Play

1. Run the application
2. Choose your move from the menu (Rock, Paper, or Scissors)
3. The computer will make its move
4. View the round result and updated score
5. Repeat and try to beat the AI!

## Architecture

This project follows Clean Architecture principles with three distinct layers:

### Domain Layer (`RockPaperScissors.Domain`)
- Contains core game rules and business logic
- No dependencies on other layers
- Defines the `Round` entity and game result calculation

### Application Layer (`RockPaperScissors.Application`)
- Contains use cases and application logic
- Depends only on the Domain layer
- Implements different AI strategies using the Strategy pattern

### Presentation Layer (`RockPaperScissors.ConsoleLineInterface`)
- Console UI implementation using Spectre.Console
- Depends on Application layer
- Handles user input and display

## Contributing

We welcome contributions! Here's how you can help:

### Reporting Issues

1. Check if the issue already exists in the [Issues](https://github.com/felipedferreira/rock-paper-scissors-game/issues) section
2. If not, create a new issue with:
   - A clear, descriptive title
   - Steps to reproduce the problem
   - Expected vs actual behavior
   - Your environment (.NET version, OS, terminal)

### Contributing Code

1. **Fork the repository**
   ```bash
   # Click the "Fork" button on GitHub
   ```

2. **Clone your fork**
   ```bash
   git clone https://github.com/your-username/rock-paper-scissors-game.git
   cd rock-paper-scissors-game
   ```

3. **Create a feature branch**
   ```bash
   git checkout -b feature/your-feature-name
   ```

4. **Make your changes**
   - Follow existing code style and conventions
   - Keep commits atomic and well-described
   - Add tests if applicable

5. **Build and test locally**
   ```bash
   dotnet build
   dotnet run --project src/apps/RockPaperScissors.ConsoleLineInterface/RockPaperScissors.ConsoleLineInterface.csproj
   ```

6. **Commit your changes**
   ```bash
   git add .
   git commit -m "feat: add your feature description"
   ```

7. **Push to your fork**
   ```bash
   git push origin feature/your-feature-name
   ```

8. **Create a Pull Request**
   - Go to the original repository on GitHub
   - Click "New Pull Request"
   - Select your fork and branch
   - Provide a clear description of your changes

### Development Guidelines

- **Code Style**: Follow C# coding conventions and use meaningful variable names
- **Architecture**: Respect the Clean Architecture boundaries - don't add dependencies that violate layer separation
- **Commits**: Use conventional commit messages (feat:, fix:, docs:, refactor:, etc.)
- **Testing**: Add unit tests for new features (when test project is added)

### Ideas for Contributions

- Add unit tests
- Implement new AI strategies
- Add a "Best of N" game mode
- Add Rock-Paper-Scissors-Lizard-Spock variant
- Improve UI/UX with more animations
- Add sound effects
- Create a web-based version
- Add multiplayer support
- Implement game statistics persistence

## Dependencies

- [Spectre.Console](https://spectreconsole.net/) - Beautiful console UI framework
- [Microsoft.Extensions.Hosting](https://www.nuget.org/packages/Microsoft.Extensions.Hosting/) - Dependency injection and hosting

## License

This project is open source. Feel free to use it as you wish.

## Acknowledgments

- Built with [Spectre.Console](https://spectreconsole.net/) for a beautiful terminal experience
- Inspired by the classic Rock-Paper-Scissors game
