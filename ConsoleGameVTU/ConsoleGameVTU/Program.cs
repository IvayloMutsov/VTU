using System;
using System.Threading;

namespace ConsoleGameVTU
{
    internal class Program
    {
        public static char startGame;
        public static int playerX, playerY;
        public static int exitX, exitY;
        public static int width, height;
        public static int score;
        public static char[,] gameBoard;
        public static Random rand = new Random(); //randomizing effect
        public static bool isGameOver; //game over condition
        private static int previousPlayerX, previousPlayerY; // Track previous player position

        static void Main()
        {
            //Setting upp the start menu
            StartMenu(startGame);
            // Set up console window size and hide the cursor to prevent flickering
            width = Console.WindowWidth;
            height = Console.WindowHeight;
            Console.SetWindowSize(width, height);
            Console.CursorVisible = false; // Hide cursor to avoid flickering

            // Initialize game state
            InitializeGame();

            while (!isGameOver)
            {
                 Draw(); // Draw the current state
                 ProcessInput(); // Process player input
                 MovePlayer(); // Move player based on input
                 CheckForCollisions(); // Check for collisions with obstacles
                 Thread.Sleep(10);  // Game speed control
            }
            // Chaek if the player has reached the exit or hit an obstacle
            if (playerX == exitX && playerY == exitY)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Game Over! You collected {score} * symbols.");
                Thread.Sleep(1000);
            }
            else
            {
                score = 0;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Clear();
                Console.WriteLine("Game over! You lost all your *\nBetter luck next time.");
            }
        }

        private static void InitializeGame()
        {
            // Initialize player starting position
            playerX = 0;
            playerY = 0;
            score = 0;
            exitX = width - 1;
            exitY = height - 1;
            // Initialize game board
            gameBoard = new char[height, width];
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    if (x == playerX && y == playerY)
                        gameBoard[y, x] = 'H';  // Initial player position
                    else if (x == exitX && y == exitY)
                        gameBoard[y, x] = 'E';  // Exit position
                    else
                        gameBoard[y, x] = ' ';  // Empty space
                }
            }

            // Spawn obstacles and collectibles
            SpawnObstacles(20);
            SpawnCollectibles(8); // Spawn collectibles at the start
            isGameOver = false;

            // Track the player's initial position
            previousPlayerX = playerX;
            previousPlayerY = playerY;
        }

        private static void Draw()
        {
            // Clear the console and redraw the entire board
            Console.Clear();

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    if (gameBoard[y, x] == 'H') // If it's the player
                    {
                        Console.SetCursorPosition(x, y);
                        Console.ForegroundColor = ConsoleColor.Blue; // Set player color to Purple
                        Console.Write('H'); // Draw player at the new position
                    }
                    else if (gameBoard[y, x] == 'E') // If it's the exit
                    {
                        Console.SetCursorPosition(x, y);
                        Console.ForegroundColor = ConsoleColor.Green; // Set exit color to Dark Green
                        Console.Write('E'); // Draw exit at its position
                    }
                    else if (gameBoard[y, x] == '*') // If it's a collectible
                    {
                        Console.SetCursorPosition(x, y);
                        Console.ForegroundColor = ConsoleColor.Cyan; // Set collectible color to Yellow
                        Console.Write('*'); // Draw collectible
                    }
                    else if (gameBoard[y, x] == '=') // If it's an obstacle
                    {
                        Console.SetCursorPosition(x, y);
                        Console.ForegroundColor = ConsoleColor.DarkRed; // Set obstacle color to Red
                        Console.Write('='); // Draw obstacle
                    }
                }
            }

            // Reset the console color back to default
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        private static void ProcessInput()
        {
            if (Console.KeyAvailable)
            {
                var key = Console.ReadKey(intercept: true).Key;

                switch (key)
                {
                    case ConsoleKey.UpArrow:
                        if (playerY > 0) playerY--;
                        break;
                    case ConsoleKey.DownArrow:
                        if (playerY < height - 1) playerY++;
                        break;
                    case ConsoleKey.LeftArrow:
                        if (playerX > 0) playerX--;
                        break;
                    case ConsoleKey.RightArrow:
                        if (playerX < width - 1) playerX++;
                        break;
                }
            }
        }

        private static void MovePlayer()
        {
            // Remove old player position and set new position
            gameBoard[previousPlayerY, previousPlayerX] = ' '; // Clear the previous position
            previousPlayerX = playerX;
            previousPlayerY = playerY;

            // If the player moves to a collectible (`*`), increase the score and spawn new collectible
            if (gameBoard[playerY, playerX] == '*')
            {
                score++;
                gameBoard[playerY, playerX] = ' ';  // Remove the collectible
                SpawnCollectibles(1);  // Spawn a new collectible
                SpawnObstacles(2); // Spawn obstacles
            }

            // If the player reaches the exit, end the game
            if (playerX == exitX && playerY == exitY)
            {
                isGameOver = true;
                return;
            }

            // If the player moves to an obstacle (`=`), reset the game
            if (gameBoard[playerY, playerX] == '=')
            {
                isGameOver = true;
                return;
            }

            // Update the player's new position on the board
            gameBoard[playerY, playerX] = 'H';
        }

        private static void CheckForCollisions()
        {
            // If the player collides with an obstacle, end the game
            if (gameBoard[playerY, playerX] == '=')
            {
                isGameOver = true;
            }
        }

        private static void SpawnObstacles(int numObstacles)
        {
            for (int i = 0; i < numObstacles; i++)
            {
                int x, y;
                do
                {
                    x = rand.Next(1, width - 1);
                    y = rand.Next(1, height - 1);
                }
                while (gameBoard[y, x] != ' ' || (x == playerX && y == playerY) || (x == exitX && y == exitY));

                gameBoard[y, x] = '=';  // Place an obstacle
            }
        }

        private static void SpawnCollectibles(int count)
        {
            for (int i = 0; i < count; i++)
            {
                // Spawn a single collectible (`*`)
                int x, y;
                do
                {
                    x = rand.Next(1, width - 1);
                    y = rand.Next(1, height - 1);
                }
                while (gameBoard[y, x] != ' ' || (x == playerX && y == playerY) || (x == exitX && y == exitY) || gameBoard[y, x] == '=');

                gameBoard[y, x] = '*';  // Place a collectible
            }
        }

        private static void StartMenu(char startGame) // Game start menu before playing
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("Console game by Ivaylo Mutsov");
            Console.WriteLine("DISCLAMER! Adjust the screen size with CTRL + mouse scrolle for better visibility.");
            Console.WriteLine("Game rules:\n 1. You are player H trying to reach the exit E\n 2. = are obstacles that will kill you\n 3. Collect * to get a highsocre.");
            Console.Write("Do you want to start playing? (Y/n) ");
            startGame = char.Parse(Console.ReadLine());
            if (startGame == 'n' || startGame == 'N')
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("You chose not to play. :(");
                Environment.Exit(0);
            }
            else
            {
                Console.WriteLine("Good Luck!");
                Thread.Sleep(1000);
                Console.Clear();
            }
        }
    }
}