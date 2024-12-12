using System;

namespace SudokuGame
{
    class Game
    {
        private SudokuBoard board;

        public Game()
        {
            board = new SudokuBoard();
        }

        public void Run()
        {
            Console.WriteLine("Welcome to Sudoku!");

            while (true)
            {
                board.PrintBoard();
                Console.WriteLine("Enter your move in the format 'row column value' (e.g., 1 3 5), type 'restart' to start a new game, or type 'exit' to quit:");
                string? input = Console.ReadLine();

                if (input == null)
                    continue;

                if (input.ToLower() == "exit")
                    break;

                if (input.ToLower() == "restart")
                {
                    board = new SudokuBoard();
                    Console.WriteLine("Game restarted!");
                    continue;
                }

                string[] parts = input.Split(' ');
                if (parts.Length == 3 &&
                    int.TryParse(parts[0], out int row) &&
                    int.TryParse(parts[1], out int col) &&
                    int.TryParse(parts[2], out int value))
                {
                    if (board.MakeMove(row - 1, col - 1, value))
                    {
                        if (board.IsComplete())
                        {
                            board.PrintBoard();
                            Console.WriteLine("Congratulations! You've completed the Sudoku!");
                            break;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid move! Please try again.");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input format! Please follow the 'row column value' format.");
                }
            }
        }
    }
}