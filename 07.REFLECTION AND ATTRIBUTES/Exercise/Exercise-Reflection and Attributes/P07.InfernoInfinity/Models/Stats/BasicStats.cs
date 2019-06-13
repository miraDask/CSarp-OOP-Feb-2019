namespace P07.InfernoInfinity.Models.Stats
{
    using P07.InfernoInfinity.Models.Contracts;
    using System;
    using System.Collections.Generic;

    public class BasicStats
    {
        private const int MinDamageIncreasementByStrength = 2;
        private const int MaxDamageIncreasementByStrength = 3;
        private const int MinDamageIncreasementByAgility = 1;
        private const int MaxDamageIncreasementByAgility = 4;

        private int minDamage;
        private int maxDamage;
        private IGem[] sockets;

        public BasicStats(int minDamage, int maxDamage, IGem[] sockets)
        {
            this.MinDamage = minDamage;
            this.MaxDamage = maxDamage;
            this.Sockets = sockets;
        }

        public int MinDamage { get; private set; }

        public int MaxDamage { get; private set; }

        public IGem[] Sockets { get; private set; }


        public void IncreaseDamageByRarity(Rarity rarity)
        {
            int value = (int)rarity;
            this.MinDamage *= value;
            this.MaxDamage *= value;
        }

        public void IncreaseDamageByMagicStats(MagicStats magicStats)
        {
            this.MinDamage += (magicStats.Strength * MinDamageIncreasementByStrength)
                + (magicStats.Agility * MinDamageIncreasementByAgility);

            this.MaxDamage += (magicStats.Strength * MaxDamageIncreasementByStrength)
                + (magicStats.Agility * MaxDamageIncreasementByAgility);
        }
    }
}
