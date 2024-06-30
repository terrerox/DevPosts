namespace OOP.Polymorphism
{
    public class AnimeCharacter {

        public virtual string SpecialMove() {
            return "Basic Attack";
        }
    }

    public class Ichigo : AnimeCharacter {

        public override string SpecialMove() {
            return "Getsuga Tensho";
        }
    }

    public class Sasuke : AnimeCharacter {

        public override string SpecialMove() {
            return "Chidori";
        }
    }
}