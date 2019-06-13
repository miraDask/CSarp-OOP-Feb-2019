namespace P07.InfernoInfinity.Models.Weapons
{
    using P07.InfernoInfinity.Models.Contracts;
    using P07.InfernoInfinity.Models.Stats;

    public class Knife : Weapon
    {
        private const int KnifeMinDamade = 3;
        private const int KnifeMaxDamage = 4;
        private const int KnifeSockets = 2;

        public Knife(string name, Rarity rarity) : base(name, rarity)
        {
            this.BasicStats = new BasicStats(KnifeMinDamade, KnifeMaxDamage, new IGem[KnifeSockets]);
        }
    }
}
