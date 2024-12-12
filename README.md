# Sudoku Game

This is a simple console-based Sudoku game implemented in C#. The game generates a random Sudoku puzzle and allows the user to solve it by entering moves.

## Features

- Generates a random Sudoku puzzle each time the game starts.
- Allows the user to enter moves in the format `row column value`.
- Provides options to restart the game or exit.
- Checks for valid moves and ensures the puzzle is solvable.
- Displays the Sudoku board in a user-friendly format.

## Getting Started

### Prerequisites

- [.NET SDK](https://dotnet.microsoft.com/download) installed on your machine.

### Running the Game

1. Clone the repository or download the source code.
2. Open a terminal and navigate to the project directory.
3. Build the project using the following command:
   ```sh
   dotnet build
   dotnet run
### Playing the Game
When the game starts, a random Sudoku puzzle will be displayed.
Enter your move in the format row column value (e.g., 1 3 5).
Type restart to start a new game with a new puzzle.
Type exit to quit the game.
## Project Structure
Program.cs: The entry point of the application.
Game.cs: Contains the main game loop and handles user input.
SudokuBoard.cs: Contains the logic for generating and managing the Sudoku board.
