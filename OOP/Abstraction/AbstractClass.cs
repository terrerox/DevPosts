namespace OOP.Abstraction
{
    public abstract class AnimeCharacter {

        public abstract string SpecialAttack();

        public virtual string Goal() {
            return "Save the planet";
        }
    }

    public class Goku : AnimeCharacter {

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
}