
namespace PlayerExercise.Domain
{
    public class Player
    {
        // Proprietà del giocatore
        public string Name { get; set; }

        public int Level { get; private set; }

        public int Experience { get; private set; }

        public int Health { get; private set; }

        public int MaxHealth { get; private set; }

        public bool IsAlive { get; private set; }

        public int Gold { get; private set; }

        // Costruttore: inizializza il giocatore con i valori predefiniti
        public Player(string name)
        {
            Name = name;
            Level = 1;
            Experience = 0;
            MaxHealth = 100;
            Health = MaxHealth;
            IsAlive = true;
            Gold = 0;
        }

        // Aggiunge esperienza e aumenta il livello ogni 100 punti
        public void AddExperience(int amount)
        {
            // Ignora valori nulli o negativi
            if (amount <= 0)
            {
                return;
            }

            // Evita l'overflow quando si somma l'esperienza
            if (amount > int.MaxValue - Experience)
            {
                return;
            }

            Experience += amount;

            // Aumenta il livello conservando l'esperienza rimanente
            while (Experience >= 100)
            {
                Experience -= 100;
                Level++;
            }
        }

        // Azzera l'esperienza del giocatore
        public void ResetExperience()
        {
            Experience = 0;
        }

        // Riduce i punti vita del giocatore
        public void TakeDamage(int amount)
        {
            // Ignora danni nulli, negativi o ricevuti da un giocatore morto
            if (amount <= 0 || !IsAlive)
            {
                return;
            }

            // Se il danno è sufficiente, il giocatore muore
            if (amount >= Health)
            {
                Health = 0;
                IsAlive = false;
            }
            else
            {
                Health -= amount;
            }
        }

        // Cura il giocatore senza superare i punti vita massimi
        public void Heal(int amount)
        {
            // Ignora cure nulle, negative o effettuate su un giocatore morto
            if (amount <= 0 || !IsAlive)
            {
                return;
            }

            // Evita di superare MaxHealth e di causare overflow
            if (amount >= MaxHealth - Health)
            {
                Health = MaxHealth;
            }
            else
            {
                Health += amount;
            }
        }

        // Aggiunge oro al giocatore
        public void AddGold(int amount)
        {
            // Ignora quantità nulle o negative
            if (amount <= 0)
            {
                return;
            }

            // Evita l'overflow della quantità di oro
            if (amount > int.MaxValue - Gold)
            {
                return;
            }

            Gold += amount;
        }

        // Ripristina i punti vita e riporta il giocatore in vita
        public void ResetHealth()
        {
            Health = MaxHealth;
            IsAlive = true;
        }

        // Restituisce una descrizione completa del giocatore
        public override string ToString()
        {
            return $"Name: {Name}, Level: {Level}, Experience: {Experience}, " +
                   $"Health: {Health}/{MaxHealth}, IsAlive: {IsAlive}, Gold: {Gold}";
        }
    }
}




