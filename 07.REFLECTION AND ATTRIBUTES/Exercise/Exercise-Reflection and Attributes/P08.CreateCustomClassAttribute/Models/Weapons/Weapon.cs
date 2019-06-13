namespace P07.InfernoInfinity.Models.Weapons
{
    using P07.InfernoInfinity.Models.Contracts;
    using P07.InfernoInfinity.Models.CustomAttributes;
    using P07.InfernoInfinity.Models.Stats;

    [ClassInfo("Pesho", 3 , "Used for C# OOP Advanced Course - Enumerations and Attributes.", "Pesho", "Svetlio")]
    public abstract class Weapon : IWeapon
    {
        private string name;
        private Rarity rarity;
        private MagicStats magicStats = new MagicStats();

        protected Weapon(string name, Rarity rarity)
        {
            this.Name = name;
            this.Rarity = rarity;
            this.MagicStats = magicStats;
        }
        
        public string Name { get; protected set; }

        public Rarity Rarity { get; protected set; }

        public BasicStats BasicStats { get; protected set; }

        public MagicStats MagicStats { get; protected set; }

        public void SetTotalBasicStatsValue()
        {
            this.BasicStats.IncreaseDamageByRarity(this.Rarity);
            this.BasicStats.IncreaseDamageByMagicStats(this.magicStats);
        }
         
        public void SetTotalStatsValue()
        {
            SetTotalMagicStatsValue();
            SetTotalBasicStatsValue();
        }

        private void SetTotalMagicStatsValue()
        {
            foreach (var gem in this.BasicStats.Sockets)
            {
                if (gem != null)
                {
                    int strengthIncreasmentValue = gem.StrengthIncreasmentValue + (int)gem.Clarity;
                    int agilityIncreasmentValue = gem.AgilityIncreasmentValue + (int)gem.Clarity;
                    int vitalityIncreasmentValue = gem.VitalityIncreasmentValue + (int)gem.Clarity;
                    this.MagicStats.IncreaseValues(strengthIncreasmentValue, agilityIncreasmentValue, vitalityIncreasmentValue);
                }
            }
        }

        public void AddGem(IGem gem, int indexOfSocket)
        {
            if (IsInRange(indexOfSocket))
            {
                this.BasicStats.Sockets[indexOfSocket] = gem;
            }
        }

        public void RemoveGem(int indexOfSocket)
        {
            if (IsInRange(indexOfSocket))
            {
                this.BasicStats.Sockets[indexOfSocket] = null;
            }
        }

        private bool IsInRange(int indexOfSocket)
        {
            return  indexOfSocket >= 0 && indexOfSocket < this.BasicStats.Sockets.Length;
        }

        public override string ToString()
        {
            return $"{this.Name}:" +
                $" {this.BasicStats.MinDamage}-{this.BasicStats.MaxDamage} Damage," +
                $" +{this.magicStats.Strength} Strength," +
                $" +{this.magicStats.Agility} Agility," +
                $" +{this.magicStats.Vitality} Vitality";
        }
    }
}
