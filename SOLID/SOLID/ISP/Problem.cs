namespace SOLID.ISP.Problem;

public interface IAnimeCharacter
{
    string Name { get; set; }
    string Power { get; set; }
    void Display();
    void Attack();
    void Defend(); // Not all characters may need this method
}

public class Hero : IAnimeCharacter
{
    public string Name { get; set; }
    public string Power { get; set; }
    public string HeroicTitle { get; set; }

    public void Display()
    {
        Console.WriteLine($"Hero: {Name}, Title: {HeroicTitle}, Power: {Power}");
    }

    public void Attack()
    {
        Console.WriteLine($"Hero {Name} attacks heroically with {Power}!");
    }

    public void Defend()
    {
        Console.WriteLine($"Hero {Name} defends bravely!");
    }
}

public class Villain : IAnimeCharacter
{
    public string Name { get; set; }
    public string Power { get; set; }
    public string EvilPlan { get; set; }

    public void Display()
    {
        Console.WriteLine($"Villain: {Name}, Plan: {EvilPlan}, Power: {Power}");
    }

    public void Attack()
    {
        Console.WriteLine($"Villain {Name} attacks maliciously with {Power}!");
    }

    public void Defend()
    {
        // Villain may not have a defend action
        throw new NotImplementedException($"{Name} does not defend!");
    }
}