using System;

namespace pa5
{
    public interface ICharacter
    {
        string Name { get; }
        int Health { get; set; }
        int MaxPower { get; }
        int AttackStrength { get; }
        int DefenseStrength { get; set; }
        void Attack(ICharacter opponent);
        void Defend();
        void TakeDamage(int damage, ICharacter attacker);
    }

    public class JackSparrow : ICharacter
    {
        private static readonly Random random = new Random();
        private bool isDefending = false;

        public string Name { get; private set; } = "JackSparrow";
        public int Health { get; set; } = 100;
        public int MaxPower { get; private set; } = random.Next(1, 101);
        public int AttackStrength { get; private set; } = random.Next(1, 101);
        public int DefenseStrength { get; set; } = random.Next(1, 101);
        private string Strength { get; set; } = nameof(WillTurner); 

        public void Attack(ICharacter opponent)
        {
            int damage = CalculateDamage(opponent, AttackStrength);
            Console.WriteLine($"{Name} attacks {opponent.Name} for {damage} damage!");
            opponent.TakeDamage(damage, this);
        }

        public void Defend()
        {
            isDefending = true;
            Console.WriteLine($"{Name} is now defending. Incoming damage will be reduced.");
        }

        public void TakeDamage(int damage, ICharacter attacker)
        {
            if (isDefending)
            {
                damage = Math.Max(0, damage - DefenseStrength);
                Console.WriteLine($"{Name} is defending! Damage reduced.");
            }

            Health = Math.Max(0, Health - damage);
            Console.WriteLine($"{Name} takes {damage} damage. Health left: {Health}");
            isDefending = false;
        }

        private int CalculateDamage(ICharacter opponent, int baseDamage)
        {
            
            if (opponent.GetType().Name == Strength)
            {
                baseDamage = (int)(baseDamage * 1.2); 
                Console.WriteLine($"{Name}'s attack is strong against {opponent.Name}! Damage increased by 20%.");
            }
            return baseDamage;
        }
    }

    public class DavyJones : ICharacter
    {
        private static readonly Random random = new Random();
        private bool isDefending = false;

        public string Name { get; private set; } = "DavyJones";
        public int Health { get; set; } = 100;
        public int MaxPower { get; private set; } = random.Next(1, 101);
        public int AttackStrength { get; private set; } = random.Next(1, 101);
        public int DefenseStrength { get; set; } = random.Next(1, 101);
        private string Strength { get; set; } = nameof(JackSparrow); 

        public void Attack(ICharacter opponent)
        {
            int damage = CalculateDamage(opponent, AttackStrength);
            Console.WriteLine($"{Name} attacks {opponent.Name} for {damage} damage!");
            opponent.TakeDamage(damage, this);
        }

        public void Defend()
        {
            isDefending = true;
            Console.WriteLine($"{Name} is now defending. Incoming damage will be reduced.");
        }

        public void TakeDamage(int damage, ICharacter attacker)
        {
            if (isDefending)
            {
                damage = Math.Max(0, damage - DefenseStrength);
                Console.WriteLine($"{Name} is defending! Damage reduced.");
            }

            Health = Math.Max(0, Health - damage);
            Console.WriteLine($"{Name} takes {damage} damage. Health left: {Health}");
            isDefending = false;
        }

        private int CalculateDamage(ICharacter opponent, int baseDamage)
        {
            if (opponent.GetType().Name == Strength)
            {
                baseDamage = (int)(baseDamage * 1.2); 
                Console.WriteLine($"{Name}'s attack is strong against {opponent.Name}! Damage increased by 20%.");
            }
            return baseDamage;
        }
    }

    public class WillTurner : ICharacter
    {
        private static readonly Random random = new Random();
        private bool isDefending = false;

        public string Name { get; private set; } = "WillTurner";
        public int Health { get; set; } = 100;
        public int MaxPower { get; private set; } = random.Next(1, 101);
        public int AttackStrength { get; private set; } = random.Next(1, 101);
        public int DefenseStrength { get; set; } = random.Next(1, 101);
        private string Strength { get; set; } = nameof(DavyJones); // Will Turner is strong against Davy Jones

        public void Attack(ICharacter opponent)
        {
            int damage = CalculateDamage(opponent, AttackStrength);
            Console.WriteLine($"{Name} attacks {opponent.Name} for {damage} damage!");
            opponent.TakeDamage(damage, this);
        }

        public void Defend()
        {
            isDefending = true;
            Console.WriteLine($"{Name} is now defending. Incoming damage will be reduced.");
        }

        public void TakeDamage(int damage, ICharacter attacker)
        {
            if (isDefending)
            {
                damage = Math.Max(0, damage - DefenseStrength);
                Console.WriteLine($"{Name} is defending! Damage reduced.");
            }

            Health = Math.Max(0, Health - damage);
            Console.WriteLine($"{Name} takes {damage} damage. Health left: {Health}");
            isDefending = false;
        }

        private int CalculateDamage(ICharacter opponent, int baseDamage)
        {
            if (opponent.GetType().Name == Strength)
            {
                baseDamage = (int)(baseDamage * 1.2);
                Console.WriteLine($"{Name}'s attack is strong against {opponent.Name}! Damage increased by 20%.");
            }
            return baseDamage;
        }
    }
}
