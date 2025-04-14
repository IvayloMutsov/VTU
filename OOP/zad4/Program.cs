using System;
using System.Collections.Generic;

namespace balloonPop
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Balloon Pop Game!");
            Console.Write("Enter Player 1's name: ");
            string player1Name = Console.ReadLine();
            Console.Write("Enter Player 2's name: ");
            string player2Name = Console.ReadLine();

            Game game = new Game(player1Name, player2Name);
            game.Start();
        }
    }
}