using System;
using System.Collections.Generic;

namespace TicTacToe
{
    class Program
    {
        static void Main(string[] args)
        {
            Board gameBoard = new Board();
            gameBoard.PrintBoard();

            List<int> occupiedPositions = new List<int>();
            char playerSign = 'x';

            while (CheckWin(gameBoard).Equals(' '))
            {
                Console.WriteLine("type 1-9");
                string playerInput = Console.ReadLine();
                bool playerInputCheck = Int32.TryParse(playerInput, out int playerPosition);
                

                if (occupiedPositions.Contains(playerPosition) || !playerInputCheck)
                {
                    Console.WriteLine("Please type a valid open position");
                    gameBoard.PrintBoard();
                    continue;
                }
                else
                {
                    gameBoard.UpdateBoard(playerPosition - 1, playerSign);
                    occupiedPositions.Add(playerPosition);
                }

                switch (playerSign)
                {
                    case 'x':
                        playerSign = 'o';
                        break;
                    case 'o':
                        playerSign = 'x';
                        break;
                }

                gameBoard.PrintBoard();
            }

            Console.WriteLine("The Winner is Player {0}!", CheckWin(gameBoard));
            Console.WriteLine("Press Enter to Quit");
            Console.ReadKey();
        }

        public static char CheckWin(Board gameBoard)
        {
            for(int i = 0; i < 3; i++)
            {
                //check horizontal win
                if(!((int)gameBoard.board[i,0]).Equals(0) && gameBoard.board[i, 0].Equals(gameBoard.board[i,1]) && gameBoard.board[i, 0].Equals(gameBoard.board[i, 2]))
                {
                    return gameBoard.board[i, 0];
                }

                //check vertical win
                if(!((int)gameBoard.board[0, i]).Equals(0) && gameBoard.board[0,i].Equals(gameBoard.board[1,i]) && gameBoard.board[0, i].Equals(gameBoard.board[2, i]))
                {
                    return gameBoard.board[0, i];
                }
            }

            //check diagonal win
            if(!((int)gameBoard.board[0,0]).Equals(0) && gameBoard.board[0,0].Equals(gameBoard.board[1,1]) && gameBoard.board[0, 0].Equals(gameBoard.board[2, 2]))
            {
                return gameBoard.board[0, 0];
            }

            if (!((int)gameBoard.board[0, 2]).Equals(0) && gameBoard.board[0, 2].Equals(gameBoard.board[1, 1]) && gameBoard.board[0, 2].Equals(gameBoard.board[2, 0]))
            {
                return gameBoard.board[0, 2];
            }

            return ' ';
        }
    }
}
