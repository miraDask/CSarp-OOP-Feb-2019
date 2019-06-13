namespace P07.InfernoInfinity.Models.Weapons
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using P07.InfernoInfinity.Models.Contracts;
    using P07.InfernoInfinity.Models.Stats;

    public class Axe : Weapon
    {
        private const int AxeMinDamade = 5;
        private const int AxeMaxDamage = 10;
        private const int AxeSockets = 4;
        
        public Axe(string name, Rarity rarity)
            : base(name, rarity)
        {
            this.BasicStats = new BasicStats(AxeMinDamade, AxeMaxDamage, new IGem[AxeSockets]);
        }
    }
}
