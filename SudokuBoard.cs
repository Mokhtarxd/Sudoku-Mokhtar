    using System;

    namespace SudokuGame
    {
        class SudokuBoard
        {
            private int[,] board;
            private Random random;

            public SudokuBoard()
            {
                board = new int[9, 9];
                random = new Random();
                GenerateBoard();
            }

            private void GenerateBoard()
            {
                // Clear the board
                for (int i = 0; i < 9; i++)
                {
                    for (int j = 0; j < 9; j++)
                    {
                        board[i, j] = 0;
                    }
                }

                // Fill the board with a valid Sudoku solution
                FillBoard();

                // Remove some numbers to create the puzzle
                RemoveNumbers();
            }

            private bool FillBoard()
            {
                for (int i = 0; i < 9; i++)
                {
                    for (int j = 0; j < 9; j++)
                    {
                        if (board[i, j] == 0)
                        {
                            for (int num = 1; num <= 9; num++)
                            {
                                if (IsValidMove(i, j, num))
                                {
                                    board[i, j] = num;
                                    if (FillBoard())
                                    {
                                        return true;
                                    }
                                    board[i, j] = 0;
                                }
                            }
                            return false;
                        }
                    }
                }
                return true;
            }

            private void RemoveNumbers()
            {
                int cellsToRemove = 40; // Adjust this number to change difficulty
                while (cellsToRemove > 0)
                {
                    int row = random.Next(9);
                    int col = random.Next(9);
                    if (board[row, col] != 0)
                    {
                        board[row, col] = 0;
                        cellsToRemove--;
                    }
                }
            }

            public void PrintBoard()
            {
                Console.WriteLine("   1 2 3   4 5 6   7 8 9");
                for (int i = 0; i < 9; i++)
                {
                    if (i % 3 == 0) Console.WriteLine("  +-------+-------+-------+");
                    Console.Write((i + 1) + " | ");
                    for (int j = 0; j < 9; j++)
                    {
                        Console.Write(board[i, j] == 0 ? ". " : board[i, j] + " ");
                        if ((j + 1) % 3 == 0) Console.Write("| ");
                    }
                    Console.WriteLine();
                }
                Console.WriteLine("  +-------+-------+-------+");
            }

            public bool IsValidMove(int row, int col, int value)
            {
                if (row < 0 || row >= 9 || col < 0 || col >= 9 || value < 1 || value > 9 || board[row, col] != 0)
                    return false;

                for (int i = 0; i < 9; i++)
                {
                    if (board[row, i] == value || board[i, col] == value)
                        return false;
                }

                int startRow = (row / 3) * 3;
                int startCol = (col / 3) * 3;
                for (int i = startRow; i < startRow + 3; i++)
                {
                    for (int j = startCol; j < startCol + 3; j++)
                    {
                        if (board[i, j] == value)
                            return false;
                    }
                }

                return true;
            }

            public bool MakeMove(int row, int col, int value)
            {
                if (IsValidMove(row, col, value))
                {
                    board[row, col] = value;
                    return true;
                }
                return false;
            }

            public bool IsComplete()
            {
                for (int i = 0; i < 9; i++)
                {
                    for (int j = 0; j < 9; j++)
                    {
                        if (board[i, j] == 0)
                            return false;
                    }
                }
                return true;
            }
        }
    }