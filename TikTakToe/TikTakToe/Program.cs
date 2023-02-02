using BoardLogic;
using System;
namespace TikTacToe
{
    class Program
    {
        static Board game = new Board();

        static void Main(string[] args)
        {

            int userTurn = -1;
            int computerTurn = -1;

            Random rand = new Random();

            // keep playing until someone wins
            while (game.checkForWinner() == 0)
            {
                // get valid input from the user
                while (userTurn == -1 || game.Grid[userTurn] != 0)
                {
                    Console.WriteLine("Please enter a number between 0 and 8");
                    userTurn = int.Parse(Console.ReadLine());
                    Console.WriteLine("You typed " + userTurn);
                }
                game.Grid[userTurn] = 1;

                if (game.isBoardFull())
                    break;

                // get a random move from the computer
                while (computerTurn == -1 || game.Grid[computerTurn] != 0)
                {
                    computerTurn = rand.Next(9);

                    Console.WriteLine("Computer chooses " + computerTurn);
                }
                game.Grid[computerTurn] = 2;

                if (game.isBoardFull())
                    break;

                // show the board
                printBoard();


            }
            Console.WriteLine("Player " + game.checkForWinner() + " won the game!");
            Console.ReadLine();

        }
        

        private static void printBoard()
        {
            for (int i = 0; i < game.Grid.Length; i++)
            {
                if (i % 3 == 0)
                    Console.WriteLine();
                if (game.Grid[i] == 0)
                {
                    Console.Write(".");
                }
                else if (game.Grid[i] == 1)
                {
                    Console.Write("X");
                }
                else
                {
                    Console.Write("O");
                }
            }
            Console.WriteLine("------------------");
        }

    }
}