public class Game
{
    private Player Player1;
    private Player Player2;

    public Game(string player1Name, string player2Name)
    {
        Player1 = new Player(player1Name, "Red");
        Player2 = new Player(player2Name, "Blue");

        Player1.OnWin += HandleWin;
        Player2.OnWin += HandleWin;
        Player1.OnLose += HandleLose;
        Player2.OnLose += HandleLose;
    }

    private void HandleWin(Player player)
    {
        Console.WriteLine($"{player.Name} wins the game!");
        Environment.Exit(0);
    }

    private void HandleLose(Player player)
    {
        var winner = player;
        if (player == Player1)
        {
            winner = Player2;
        }
        else
        {
            winner = Player1;
        }
        Console.WriteLine($"{player.Name} ran out of arrows! {winner.Name} wins!");
        Environment.Exit(0);
    }

    public void Start()
    {
        while (true)
        {
            Console.Clear();

            // Player 1's turn
            bool result1 = Player1.TryPopBalloon();
            if (result1)
            {
                Console.WriteLine($"{Player1.Name} popped a balloon!");
            }
            else if(Player1.SkipNextTurn == false)
            {
                Console.WriteLine($"{Player1.Name} missed!");
            }

            // Player 2's turn
            bool result2 = Player2.TryPopBalloon();
            if (result2)
            {
                Console.WriteLine($"{Player2.Name} popped a balloon!");
            }
            else if(Player2.SkipNextTurn == false)
            {
                Console.WriteLine($"{Player2.Name} missed!");
            }

            // Re-display updated stats after both moves
            Console.WriteLine();
            DisplayStatus();

            // Check for win
            if (Player1.BalloonsPopped == 10 && Player2.BalloonsPopped == 10)
            {
                Console.WriteLine("Both players popped all balloons — it's a tie!");
                break;
            }
            else if (Player1.BalloonsPopped == 10)
            {
                Console.WriteLine($"{Player1.Name} wins by popping all balloons!");
                break;
            }
            else if (Player2.BalloonsPopped == 10)
            {
                Console.WriteLine($"{Player2.Name} wins by popping all balloons!");
                break;
            }

            // Check for both out of arrows
            if (Player1.ArrowsUsed >= 10 && Player2.ArrowsUsed >= 10)
            {
                Console.WriteLine("Both players are out of arrows!");

                if (Player1.BalloonsPopped > Player2.BalloonsPopped)
                {
                    Console.WriteLine($"{Player1.Name} wins with more balloons popped!");
                }
                else if (Player2.BalloonsPopped > Player1.BalloonsPopped)
                {
                    Console.WriteLine($"{Player2.Name} wins with more balloons popped!");
                }
                else
                {
                    Console.WriteLine("It's a draw!");
                    break;
                }
            }

            // Check if one player ran out of arrows after this round
            if (Player1.ArrowsUsed >= 10 && Player2.ArrowsUsed < 10)
            {
                Console.WriteLine($"{Player1.Name} has run out of arrows!");
            }

            if (Player2.ArrowsUsed >= 10 && Player1.ArrowsUsed < 10)
            {
                Console.WriteLine($"{Player2.Name} has run out of arrows!");
            }

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
    }

    private void DisplayStatus()
    {
        Console.WriteLine($"{Player1.Name} (Red) - Balloons Popped: {Player1.BalloonsPopped}/10, Arrows Used: {Player1.ArrowsUsed}/10");
        Console.WriteLine($"{Player2.Name} (Blue) - Balloons Popped: {Player2.BalloonsPopped}/10, Arrows Used: {Player2.ArrowsUsed}/10");
        Console.WriteLine("--------------------------------------------");
    }
}