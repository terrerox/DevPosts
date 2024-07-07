namespace SOLID.DIP.Solution;

public interface IAnimeCharacter
{
    string Name { get; set; }
    string Power { get; set; }
    void Display();
    void Attack();
}

public interface IHero : IAnimeCharacter
{
    string HeroicTitle { get; set; }
    void Defend();
}

public interface IVillain : IAnimeCharacter
{
    string EvilPlan { get; set; }
}

public class Hero : IHero
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

public class Villain : IVillain
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
    private readonly IHero _hero;
    private readonly IVillain _villain;

    public AnimeBattle(IHero hero, IVillain villain)
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