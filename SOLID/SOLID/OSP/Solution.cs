namespace SOLID.OSP.Solution;

public abstract class AnimeCharacter
{

    public abstract string SpecialAttack(); //SpecialAttack() is now an abstract method

    public virtual string Goal() {
        return "Save the planet";
    }
}

public class Goku : AnimeCharacter {

    public override string SpecialAttack() { // Can now override SpecialAttack() from AnimeCharacter
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
