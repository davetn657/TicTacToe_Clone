using System;

namespace TicTacToe
{
    class Board
    {
        public char[,] board = new char[3, 3];

        public void PrintBoard()
        {
            Console.WriteLine("---------------");
            for(int r = 0; r < board.GetLength(0); r++)
            {
                for(int c = 0; c < board.GetLength(1); c++)
                {
                    if (((int)board[r,c]).Equals(0))
                    {
                        Console.Write("|   |");
                    }
                    else
                    {
                        Console.Write("| " + board[r, c] + " |");
                    }
                    
                }
                Console.WriteLine("\n---------------");
            }
        }

        public void UpdateBoard(int position, char player)
        {
            switch (position)
            {
                case int n when (n >= 0 && n <= 2):
                    board[0, position] = player;
                    break;
                case int n when (n >= 3 && n <= 5):
                    board[1, position - 3] = player;
                    break;
                case int n when (n >= 6 && n <= 8):
                    board[2, position - 6] = player;
                    break;
            }
        }
    }
}
