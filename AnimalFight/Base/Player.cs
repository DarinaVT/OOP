namespace AnimalFight
{
    public class Player
    {
        public Animal Animal { get; }
        public int Kills { get; set; }
        public string PlayerEmoji => Animal.Emoji;
        public bool IsDead => Animal.Life <= 0;

        private int _totalHealthBoost;
        private int _totalPowerBoost;

        public int TotalHealthBoost => _totalHealthBoost;
        public int TotalPowerBoost => _totalPowerBoost;
        public const int MaxPowerBoost = 10;

        public Player(Animal animal)
        {
            Animal = animal;
            Kills = 0;
            _totalHealthBoost = 0;
            _totalPowerBoost = 0;
        }

        public void ApplyHealthBoost(int amount)
        {
            int maxPossible = Animal.MaxLife - Animal.Life;
            int actualBoost = Math.Min(amount, maxPossible);
            Animal.Life += actualBoost;
            _totalHealthBoost += actualBoost;
        }

        public void ApplyPowerBoost(int amount)
        {
            int remaining = MaxPowerBoost - _totalPowerBoost;
            int actualBoost = Math.Min(amount, remaining);
            Animal.Power += actualBoost;
            _totalPowerBoost += actualBoost;
        }

        public bool NeedsHealth => Animal.Life < Animal.MaxLife;
        public bool NeedsPower => _totalPowerBoost < MaxPowerBoost;
    }
}