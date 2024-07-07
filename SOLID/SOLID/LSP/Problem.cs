namespace SOLID.LSP.Problem;

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
        throw new NotImplementedException("Usopp doesn't heal.");
    }
}