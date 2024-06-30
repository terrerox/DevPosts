using OOP.Polymorphism;
using OOP.Encapsulation;
using OOP.Inheritance;

namespace OOP;
class Program
{
    static void Main(string[] args)
    {
        Encapsulation();
        Inheritance();
        Polymorphism(); 
    }

    static void Encapsulation()
    {
        Console.WriteLine("Encapsulation");
        var naruto = new Ninja();
        naruto.Name = "Naruto Uzumaki";
        naruto.SetSecretTechnique("Shadow Clone Jutsu");
        naruto.SetRank("Genin");

        Console.WriteLine(naruto.Name); // Outputs "Naruto Uzumaki"
        Console.WriteLine(naruto.GetSecretTechnique()); // Outputs "Shadow Clone Jutsu"
        Console.WriteLine(naruto.GetRank()); // Outputs "Genin"
    }

    static void Inheritance()
    {
        Console.WriteLine("Inheritance");
        var naruto = new Naruto();
        Console.WriteLine(naruto.HairColor); // Outputs "yellow" from minato
    }

    static void Polymorphism()
    {
        Console.WriteLine("Polymorphism");
        // Compile time polymorphism
        Console.WriteLine("Compile time");
        var zoro = new Zoro();
        Console.WriteLine(zoro.Attack(3)); // Outputs "Attacks with 3 swords."
        Console.WriteLine(zoro.Attack("Santoryu Ogi"));   // Outputs "Uses the technique Santoryu Ogi."

        // Run time polymorphism
        Console.WriteLine("Run time");
        AnimeCharacter ichigo = new Ichigo();
        AnimeCharacter sasuke = new Sasuke();
        Console.WriteLine(ichigo.SpecialMove());  // Outputs "Getsuga Tensho"
        Console.WriteLine(sasuke.SpecialMove());  // Outputs "Chidori"
    }
}
