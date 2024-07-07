# Mastering SOLID Principles in C#

As a backend developer, there are some concepts that you must know. If you want a job in this industry, the SOLID principles are a set of guidelines that have stood the test of time and are crucial to understand. They are also common interview topics that you must answer correctly if you want to pass.

I'm going to explain all the principles to you in the easiest way I found, using anime-related examples.

![notLikeUs](https://media1.tenor.com/m/NNwdBi3d7aQAAAAC/minato.gif)

**Single Responsibility Principle**

> _A class should have only one reason to change_

Not only your class; your functions and modules should have one responsibility. This means that if you have a big function that does a lot of things, you should probably separate it into smaller functions.

```csharp 
public class Anime
{
    public string Title { get; set; }
    public string Genre { get; set; }
    public int NumberOfEpisodes { get; private set; }
    public string Studio { get; set; }
    public string Director { get; set; }
    public List<string> MainCharacters { get; private set; }
    public List<string> Episodes { get; private set; }

    public Anime(string title, string genre, string studio, string director)
    {
        Title = title;
        Genre = genre;
        Studio = studio;
        Director = director;
        MainCharacters = new List<string>();
        Episodes = new List<string>();
        NumberOfEpisodes = 0;
    }

    public void AddCharacter(string character)
    {
        MainCharacters.Add(character);
    }

    public void AddEpisode(string episode)
    {
        Episodes.Add(episode);
        NumberOfEpisodes++;
    }
}
```
Look at this class. This class manages `Episodes` and `Characters`. These fields can be turned into classes easily.

Now let's split these properties by creating their own classes:

```csharp
public class Character
{
    public string Name { get; set; }

    public Character(string name)
    {
        Name = name;
    }

    public void DisplayInfo()
    {
        Console.WriteLine($"Character: {Name}");
    }
}

public class Episode
{
    public string Title { get; set; }

    public Episode(string title)
    {
        Title = title;
    }

    public void DisplayInfo()
    {
        Console.WriteLine($"Episode: {Title}");
    }
}

public class Anime
{
    public string Title { get; set; }
    public string Genre { get; set; }
    public int NumberOfEpisodes { get { return Episodes.Count; } }
    public string Studio { get; set; }
    public string Director { get; set; }
    public List<Character> MainCharacters { get; private set; }
    public List<Episode> Episodes { get; private set; }

    public Anime(string title, string genre, string studio, string director)
    {
        Title = title;
        Genre = genre;
        Studio = studio;
        Director = director;
        MainCharacters = new List<Character>();
        Episodes = new List<Episode>();
    }

    public void AddCharacter(Character character)
    {
        MainCharacters.Add(character);
    }

    public void AddEpisode(Episode episode)
    {
        Episodes.Add(episode);
    }
}
```
Here, there is a new `Character` and `Episode` class, separating the responsibility of the `Anime` class.

> If you want to split the class more, you can create `Studio`, `Director`, and even `Genre` classes too!

---

**Open-Closed Principle**

> _Software entities (classes, modules, functions) should be open for extension, but closed for modification_

You should not modify the class if you want to add new features!

```csharp
public class AnimeCharacter {
    
    // Create a goal for each character
    public string GokuGoal() { 
        return "Save the planet";
    }
    public string GojoGoal() {
        return "Defeat Sukuna";
    }
    public string GokuSpecialAttack() {
        return "Kamehameha!!";
    }
    public string GojoSpecialAttack() {
        return "Domain expansion";
    }
}
```
Here, this class has a `Goal()` and a `SpecialAttack()` for each character, meaning that if we want to add another `Goal()` or `SpecialAttack()`, you'll have to modify the class each time.

```csharp
public abstract class AnimeCharacter
{
    //SpecialAttack() is now an abstract method
    public abstract string SpecialAttack(); 

    public virtual string Goal() {
        return "Save the planet";
    }
}

public class Goku : AnimeCharacter {

    // Can now override SpecialAttack() from AnimeCharacter
    public override string SpecialAttack() { 
        return "Kamehameha!!";
    }
}

public class Gojo : AnimeCharacter {

    public override string SpecialAttack() {
        return "Domain expansion";
    }

    public override string Goal() {
        return "Defeat Sukuna";
    }
}
```
Apply inheritance and extend its functionality. Now, there are new `Gojo` and `Goku` classes that inherit from `AnimeCharacter`, overriding each implementation in its child class!

> If you want to know more about abstraction and inheritance, I have a [post](https://dev.to/terrerox/the-key-of-oop-principles-12bm) prepared for you!

---

**Liskov Substitution Principle**

> _Derived or child classes must be substitutable for their base or parent classes_

The methods of the parent class should be replaceable by methods of the child class.

```csharp
public class StrawHat
{
    public virtual void Attack()
    {
        Console.WriteLine("StrawHat attacks.");
    }

    public virtual void Heal()
    {
        Console.WriteLine("StrawHat heals.");
    }
}

public class Chopper : StrawHat
{
    public override void Attack()
    {
        Console.WriteLine("Chopper attacks with his devil fruit power.");
    }

    public override void Heal()
    {
        Console.WriteLine("Chopper heals with his medical skills.");
    }
}

public class Usopp : StrawHat
{
    public override void Attack()
    {
        Console.WriteLine("Usopp attacks with his slingshot.");
    }

    public override void Heal()
    {
        // This will break the principle of LSP. Usopp cannot heal.
        throw new NotImplementedException("Usopp doesn't heal.");
    }
}
```
All StrawHats but `Chopper` know nothing about medicine and healing, like `Usopp`, so you shouldn't add the method `Heal` in the parent class `StrawHat`.

Instead, you should split the skills by interfaces, like this:

```csharp
public interface IAttacker
{
    void Attack();
}

public interface IHealer
{
    void Heal();
}

public class Chopper : IHealer, IAttacker
{
    public void Heal()
    {
        Console.WriteLine("Chopper heals with his medical skills.");
    }
    
    public void Attack()
    {
        Console.WriteLine("Chopper attacks with his devil fruit power.");
    }
}

public class Usopp : IAttacker
{
    public void Attack()
    {
        Console.WriteLine("Usopp attacks with his slingshot.");
    }
}
```
Now, the methods are separated by interfaces where you can implement the contract wherever you need it. This comes along with the next _Interface Segregation Principle_.

---

**Interface Segregation Principle**

> _Do not force any client to implement an interface which is irrelevant to them_

In simple words: do not create a "super" interface. This principle comes along with the _Single Responsibility Principle_.

```csharp
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
```

The `Villain` class implements the interface `IAnimeCharacter` even when the class does not need the `Defend()` function.

```csharp
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
```
Now, there are three new interfaces: `ICharacter`, `IAttackable`, and `IDefendable`, where you can use them where you really need them.

> If you don't apply the _Single Responsibility Principle_, the _Interface Segregation Principle_ won't be effective either.

---

**Dependency Inversion Principle**

> _High-level modules should not depend on low-level modules. Both should depend on abstractions_

Abstractions should not depend on details. Details (concrete implementations) should depend on abstractions.

This is very useful because you will be able to change low-level implementations without affecting high-level modules, making high-level modules independent of low-level modules.

```csharp
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
```
Here, I'm implementing `Hero` and `Villain` classes directly. Any change in either the `Hero` class or the `Villain` class (low-level) can break the `AnimeBattle` class (high-level).

```csharp
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
```
Now, any class that implements `IHero` or `IVillain` can be used in the `AnimeBattle` class, providing a flexible way to have different implementations and taking advantage of polymorphism.

Here's the [source code](https://github.com/terrerox/DevPosts) if you want to play with it!

Happy coding!

![notLikeUs](https://i.giphy.com/media/v1.Y2lkPTc5MGI3NjExZHk5MnB1bHczazFtOWgzNThzaGRzYWpsbnF2MW80MjZpbmJqZDhmeCZlcD12MV9pbnRlcm5hbF9naWZfYnlfaWQmY3Q9Zw/xAwstRzaClcNLh0BAq/giphy.gif)