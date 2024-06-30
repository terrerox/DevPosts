namespace OOP.Encapsulation
{
    public class AnimeCharacter {

        // Private field
        private string secretTechnique;

        // Public property
        public string Name { get; set; }

        // Protected property
        protected string Rank { get; set; }

        // Public method to set the private field
        public void SetSecretTechnique(string technique) {
            secretTechnique = technique;
        }

        // Public method to get the private field
        public string GetSecretTechnique() {
            return secretTechnique;
        }
    }

    public class Ninja : AnimeCharacter {

        // Public method to access the protected property
        public void SetRank(string rank) {
            Rank = rank;
        }

        // Public method to get the protected property
        public string GetRank() {
            return Rank;
        }
    }
}