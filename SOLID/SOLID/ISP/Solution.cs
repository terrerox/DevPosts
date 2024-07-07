namespace SOLID.ISP.Solution;

public interface ICharacter
{
    string Name { get; set; }
    string Power { get; set; }
    void Display();
}

public interface IAttackable
{
    void Attack();
}

public interface IDefendable
{
    void Defend();
}

public class Hero : ICharacter, IAttackable, IDefendable
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

public class Villain : ICharacter, IAttackable
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
}