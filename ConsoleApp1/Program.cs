using System;
using System.Numerics;
using Player.Exercise.Domain;

public class Program
{
    public static void Main()
    {
        // Creazione del giocatore
        Player player = new Player("Mario");

        Console.WriteLine("=== PLAYER ===");
        Console.WriteLine(player);

        // Test dell'esperienza
        Console.WriteLine("\n=== EXPERIENCE ===");

        player.AddExperience(150);

        Console.WriteLine($"Level: {player.Level}");
        Console.WriteLine($"Experience: {player.Experience}");

        // Test dell'aumento di più livelli
        player.AddExperience(250);

        Console.WriteLine($"Level after additional experience: {player.Level}");
        Console.WriteLine($"Remaining experience: {player.Experience}");

        // Test dei valori non validi per l'esperienza
        player.AddExperience(0);
        player.AddExperience(-10);

        Console.WriteLine($"Experience after invalid values: {player.Experience}");

        // Test del ripristino dell'esperienza
        player.ResetExperience();

        Console.WriteLine($"Experience after reset: {player.Experience}");

        // Test dell'oro
        Console.WriteLine("\n=== GOLD ===");

        player.AddGold(50);

        Console.WriteLine($"Gold: {player.Gold}");

        // Test dei valori non validi per l'oro
        player.AddGold(0);
        player.AddGold(-20);

        Console.WriteLine($"Gold after invalid values: {player.Gold}");

        // Test dei danni
        Console.WriteLine("\n=== HEALTH ===");

        player.TakeDamage(30);

        Console.WriteLine($"Health after taking 30 damage: {player.Health}");

        // Test della cura
        player.Heal(20);

        Console.WriteLine($"Health after healing 20 points: {player.Health}");

        // Test della cura oltre il limite massimo
        player.Heal(200);

        Console.WriteLine($"Health after excessive healing: {player.Health}");

        // Test dei danni non validi
        player.TakeDamage(0);
        player.TakeDamage(-10);

        Console.WriteLine($"Health after invalid damage: {player.Health}");

        // Test della morte
        player.TakeDamage(200);

        Console.WriteLine($"Health after lethal damage: {player.Health}");
        Console.WriteLine($"Is the player alive? {player.IsAlive}");

        // Test della cura dopo la morte
        player.Heal(50);

        Console.WriteLine($"Health after healing a dead player: {player.Health}");

        // Test dei danni dopo la morte
        player.TakeDamage(10);

        Console.WriteLine($"Health after additional damage: {player.Health}");

        // Test del ripristino della salute
        player.ResetHealth();

        Console.WriteLine($"Health after reset: {player.Health}");
        Console.WriteLine($"Is the player alive? {player.IsAlive}");

        // Test dei valori non validi per la cura
        player.TakeDamage(40);
        player.Heal(0);
        player.Heal(-10);

        Console.WriteLine($"Health after invalid healing: {player.Health}");

        // Stampa dello stato finale
        Console.WriteLine("\n=== FINAL PLAYER STATUS ===");
        Console.WriteLine(player);
    }
}

namespace Player.Exercise.Domain
{
    public class Player
    {
        public string Name { get; }
        public int Level { get; private set; } = 1;
        public int Experience { get; private set; } = 0;
        public int Gold { get; private set; } = 0;
        private const int MaxHealth = 100;
        public int Health { get; private set; }
        public bool IsAlive => Health > 0;

        public Player(string name)
        {
            Name = name;
            Health = MaxHealth;
        }

        public void AddExperience(int amount)
        {
            if (amount <= 0) return;
            Experience += amount;
            while (Experience >= 100)
            {
                Experience -= 100;
                Level++;
            }
        }

        public void ResetExperience()
        {
            Experience = 0;
            Level = 1;
        }

        public void AddGold(int amount)
        {
            if (amount > 0) Gold += amount;
        }

        public void TakeDamage(int amount)
        {
            if (amount <= 0 || !IsAlive) return;
            Health -= amount;
            if (Health < 0) Health = 0;
        }

        public void Heal(int amount)
        {
            if (amount <= 0 || !IsAlive) return;
            Health += amount;
            if (Health > MaxHealth) Health = MaxHealth;
        }

        public void ResetHealth()
        {
            Health = MaxHealth;
        }

        public override string ToString()
        {
            return $"{Name} Lv{Level} EXP:{Experience} Gold:{Gold} HP:{Health}/{MaxHealth} Alive:{IsAlive}";
        }
    }
}



