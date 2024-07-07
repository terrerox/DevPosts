namespace SOLID.DIP.Problem;

public class Hero
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

public class Villain
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

public class AnimeBattle
{
    private readonly Hero _hero;
    private readonly Villain _villain;

    public AnimeBattle(Hero hero, Villain villain)
    {
        _hero = hero;
        _villain = villain;
    }

    public void StartBattle()
    {
        _hero.Display();
        _villain.Display();
        _hero.Attack();
        _villain.Attack();
        _hero.Defend();
    }
}