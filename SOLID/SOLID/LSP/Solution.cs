namespace SOLID.LSP.Solution;

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
