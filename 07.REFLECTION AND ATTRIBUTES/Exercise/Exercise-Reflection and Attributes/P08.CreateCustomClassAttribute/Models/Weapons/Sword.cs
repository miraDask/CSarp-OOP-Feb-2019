namespace P07.InfernoInfinity.Models.Weapons
{
    using P07.InfernoInfinity.Models.Contracts;
    using P07.InfernoInfinity.Models.Stats;

    public class Sword : Weapon
    {
        private const int SwordMinDamade = 4;
        private const int SwordMaxDamage = 6;
        private const int SwordSockets = 3;

        public Sword(string name, Rarity rarity)
            : base(name, rarity)
        {
            this.BasicStats = new BasicStats(SwordMinDamade, SwordMaxDamage, new IGem[SwordSockets]);
        }
    }
}
