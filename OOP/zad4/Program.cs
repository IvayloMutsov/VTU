using System;
using System.Collections.Generic;

namespace BalloonPopGame
{
    // Balloon class to handle balloon properties and behavior
    public class Balloon
    {
        public string Color { get; private set; }
        public int Size { get; private set; }

        public Balloon(string color)
        {
            Color = color;
            Size = new Random().Next(1, 11); // Size between 1 and 10
        }
    }

    // Arrow class to handle arrow properties and behavior
    public class Arrow
    {
        public string Color { get; private set; }
        public int Accuracy { get; private set; }

        public Arrow(string color)
        {
            Color = color;
            Accuracy = new Random().Next(1, 11); // Accuracy between 1 and 10
        }

        // Check if the arrow can pop the balloon
        public bool CanPopBalloon(Balloon balloon)
        {
            return Color == balloon.Color && Accuracy >= balloon.Size;
        }
    }

    // Player class representing the players in the game
    public class Player
    {
        public string Name { get; private set; }
        public string Color { get; private set; }
        public List<Arrow> Arrows { get; private set; }
        public List<Balloon> Balloons { get; private set; }
        public int BalloonsPopped { get; private set; }
        public int ArrowsUsed { get; private set; }

        public Player(string name, string color)
        {
            Name = name;
            Color = color;
            Arrows = new List<Arrow>();
            Balloons = new List<Balloon>();
            BalloonsPopped = 0;
            ArrowsUsed = 0;

            // Initialize with 10 arrows and 10 balloons of the player's color
            for (int i = 0; i < 10; i++)
            {
                Arrows.Add(new Arrow(color));
            }
            for (int i = 0; i < 10; i++)
            {
                Balloons.Add(new Balloon(color));
            }
        }

        // Player attempts to pop a balloon with an arrow
        public bool TryPopBalloon()
        {
            if (Balloons.Count == 0)
                return false;

            var arrow = Arrows[ArrowsUsed];
            var balloon = Balloons[new Random().Next(Balloons.Count)];

            if (arrow.CanPopBalloon(balloon))
            {
                BalloonsPopped++;
                Balloons.Remove(balloon);
                ArrowsUsed++; // Arrow is used after trying
                return true;
            }
            else
            {
                ArrowsUsed++; // Arrow is used even if it misses
                return false;
            }
        }

        // Check if the player has won
        public bool HasWon() => BalloonsPopped == 10;

        // Check if the player has lost (if no arrows left)
        public bool HasLost() => ArrowsUsed >= 10;
    }

    // Game class to handle the game logic
    public class Game
    {
        private Player Player1;
        private Player Player2;

        public Game(string player1Name, string player2Name)
        {
            Player1 = new Player(player1Name, "Red");
            Player2 = new Player(player2Name, "Blue");
        }

        // Method to run the game
        public void Start()
        {
            while (true)
            {
                Console.Clear();
                DisplayStatus();

                if (Player1.HasWon())
                {
                    Console.WriteLine($"{Player1.Name} wins!");
                    break;
                }
                if (Player2.HasWon())
                {
                    Console.WriteLine($"{Player2.Name} wins!");
                    break;
                }

                if (Player1.HasLost())
                {
                    Console.WriteLine($"{Player1.Name} has run out of arrows! {Player2.Name} wins!");
                    break;
                }

                if (Player2.HasLost())
                {
                    Console.WriteLine($"{Player2.Name} has run out of arrows! {Player1.Name} wins!");
                    break;
                }

                // Player 1's turn
                if (Player1.TryPopBalloon())
                {
                    Console.WriteLine($"{Player1.Name} popped a balloon!");
                }
                else
                {
                    Console.WriteLine($"{Player1.Name} missed!");
                }

                // Player 2's turn
                if (Player2.TryPopBalloon())
                {
                    Console.WriteLine($"{Player2.Name} popped a balloon!");
                }
                else
                {
                    Console.WriteLine($"{Player2.Name} missed!");
                }

                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }
        }

        // Display the game status
        private void DisplayStatus()
        {
            Console.WriteLine($"{Player1.Name} (Red) - Balloons Popped: {Player1.BalloonsPopped}/10, Arrows Used: {Player1.ArrowsUsed}/10");
            Console.WriteLine($"{Player2.Name} (Blue) - Balloons Popped: {Player2.BalloonsPopped}/10, Arrows Used: {Player2.ArrowsUsed}/10");
            Console.WriteLine("------------------------------");
        }
    }

    // Main class to run the game
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