using balloonPop;

public class Player
{
    public string Name { get; private set; }
    public string Color { get; private set; }
    public List<Arrow> Arrows { get; private set; }
    public List<Balloon> Balloons { get; private set; }
    public int BalloonsPopped { get; private set; }
    public int ArrowsUsed { get; private set; }
    public bool SkipNextTurn { get; set; }

    public event Action<Player> OnWin;
    public event Action<Player> OnLose;
    
    public Player(string name, string color)
    {
        Name = name;
        Color = color;
        Arrows = new List<Arrow>();
        Balloons = new List<Balloon>();
        BalloonsPopped = 0;
        ArrowsUsed = 0;
        SkipNextTurn = false;

        for (int i = 0; i < 10; i++)
        {
            Arrows.Add(new Arrow(color));
            Balloons.Add(new Balloon(color));
        }

        // Add one black balloon
        Balloons.Add(new BlackBalloon());
    }

    public bool TryPopBalloon()
    {
        if (SkipNextTurn)
        {
            SkipNextTurn = false;
            Console.WriteLine($"{Name} skips this turn due to hitting a black balloon last round!");
            return false;
        }

        if (ArrowsUsed >= Arrows.Count || Balloons.Count == 0)
            return false;

        var arrow = Arrows[ArrowsUsed];
        var balloon = Balloons[new Random().Next(Balloons.Count)];
        ArrowsUsed++;

        if (balloon is BlackBalloon)
        {
            Console.WriteLine($"{Name} hit a black balloon and will skip the next turn!");
            SkipNextTurn = true;
            Balloons.Remove(balloon);
            return false;
        }

        if (arrow.CanPopBalloon(balloon))
        {
            Balloons.Remove(balloon);
            BalloonsPopped++;

            if (BalloonsPopped == 10)
                OnWin?.Invoke(this);

            return true;
        }

        return false;
    }

    public bool HasLost()
    {
        bool lost = ArrowsUsed >= Arrows.Count && BalloonsPopped < 10;
        if (lost)
            OnLose?.Invoke(this);
        return lost;
    }
}