public interface ISportsHall
{
    string Description { get; }
    decimal Price { get; }
}
public class BasicSportsHall : ISportsHall
{
    public string Description => "Базовий спортивний зал";

    public decimal Price => 500.00M;
}
public abstract class FitnessTrackerDecorator : ISportsHall
{
    protected ISportsHall sportsHall;

    public FitnessTrackerDecorator(ISportsHall sportsHall)
    {
        this.sportsHall = sportsHall;
    }

    public abstract string Description { get; }

    public abstract decimal Price { get; }
}
public class HeartRateMonitorDecorator : FitnessTrackerDecorator
{
    public HeartRateMonitorDecorator(ISportsHall sportsHall) : base(sportsHall)
    {
    }

    public override string Description => $"{sportsHall.Description} з пульсометром";

    public override decimal Price => sportsHall.Price + 50.00M;
}

public class CalorieTrackerDecorator : FitnessTrackerDecorator
{
    public CalorieTrackerDecorator(ISportsHall sportsHall) : base(sportsHall)
    {
    }

    public override string Description => $"{sportsHall.Description} з трекером калорiй";

    public override decimal Price => sportsHall.Price + 75.00M;
}
class Program
{
    static void Main(string[] args)
    {
        ISportsHall sportsHall = new BasicSportsHall();

        Console.WriteLine($"{sportsHall.Description}: ${sportsHall.Price}");

        sportsHall = new HeartRateMonitorDecorator(sportsHall);

        Console.WriteLine($"{sportsHall.Description}: ${sportsHall.Price}");

        sportsHall = new CalorieTrackerDecorator(sportsHall);

        Console.WriteLine($"{sportsHall.Description}: ${sportsHall.Price}");

        Console.ReadLine();
    }
}