namespace OOP.Polymorphism
{
    public class Zoro {

        // Method overload for attack
        public string Attack(int swords) {
            return $"Attacks with {swords} swords.";
        }

        // Method overload for a named attack
        public string Attack(string technique) {
            return $"Uses the technique {technique}.";
        }
    }
}