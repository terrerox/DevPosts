namespace OOP.Abstraction
{
    public interface IMovable {

        string Move();
    }

    public class Saitama : IMovable {

        public string Move() {
            return "Fly";
        }
    }

    public class Luffy : IMovable {

        public string Move() {
            return "Run";
        }
    }
}