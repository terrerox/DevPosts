As time passes, the way we develop software changes. It comes with new programming languages, frameworks, libraries, and now paradigms. Object-oriented programming came to change how we build our apps, providing a more maintainable, reusable, and scalable way to build. But in order to do that, you must know all the basics. That's why I am going to teach the four principles of OOP.
 
### Abstraction

Abstraction essentially hides complex implementations and only shows the necessary features of an object.

Within this principle, there are two key topics we must know about:

- **Abstract Class**: Can't be instantiated and can have abstract methods that must be overridden in the implementing class.

    ```csharp
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
    ```

    So, what's this `virtual` keyword 🤔? It allows setting default implementations for methods that can be overridden.

- **Interfaces**: A contract that the implementing class must define.

    ```csharp
    public interface IMovable {
    
       string Move();
    }
    
    public class Goku : IMovable {
        
        public string Move() {
            return "Fly";
        }
    }
    
    public class Luffy : IMovable {
        
        public string Move() {
            return "Run";
        }
    }
    ```

### Encapsulation

Encapsulation is a shield that prevents a piece of code from being accessed outside its scope.

With access modifiers, you can restrict access to your code:

- **Public**: The code has no restrictions.
- **Private**: The code can only be accessed within the class itself.
- **Protected**: Only the superclass and subclass can access the code.
- **Internal**: The code has restrictions within the same assembly/project.

```csharp
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

    var naruto = new Ninja();
    naruto.Name = "Naruto Uzumaki";
    naruto.SetSecretTechnique("Shadow Clone Jutsu");
    naruto.SetRank("Genin");

    naruto.Name; // Outputs "Naruto Uzumaki"
    naruto.GetSecretTechnique() // Outputs "Shadow Clone Jutsu"
    naruto.GetRank(); // Outputs "Genin"
```

### Inheritance

Inheritance allows methods and properties to be inherited from another class.

- **Superclass or Parent Class**

    ```csharp
    public class Minato {
    
       public string HairColor = "yellow";
            
       public string Attack() {
           return "Rasengan!!";
       }
    }
    ```
    
- **Subclass or Child Class**

    ```csharp
    public class Naruto : Minato {
       public string FavoriteFood = "ramen";

       public string Attack() {
           return "Rasengan!!";
       }
    }

    var naruto = new Naruto();
    naruto.HairColor; // Outputs "yellow"
    ```

### Polymorphism

Polymorphism allows classes to have different implementations of methods that are called by the same name.

It comes in two forms:

- **Compile-time (method overload)**

    ```csharp
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

    var zoro = new Zoro();
    zoro.Attack(3);                // Outputs "Attacks with 3 swords."
    zoro.Attack("Santoryu Ogi");   // Outputs "Uses the technique Santoryu Ogi."
    ```

- **Run-time (method override)**

    ```csharp
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

    AnimeCharacter ichigo = new Ichigo();
    AnimeCharacter sasuke = new Sasuke();
    ichigo.SpecialMove();  // Outputs "Getsuga Tensho"
    sasuke.SpecialMove();  // Outputs "Chidori"
    ```
### Conclusion

Now you know the four principles of Object-Oriented Programming: Encapsulation, which allows you to restrict access by scope; Abstraction, which shows valuable features while hiding complex implementations; Inheritance, which enables you to reuse fields and methods; and Polymorphism, which allows you to change behavior at compile time and run time. Happy coding!