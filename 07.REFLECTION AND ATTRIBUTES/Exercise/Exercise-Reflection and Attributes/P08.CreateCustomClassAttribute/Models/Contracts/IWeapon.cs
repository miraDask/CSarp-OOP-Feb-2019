namespace P07.InfernoInfinity.Models.Contracts
{
    using P07.InfernoInfinity.Models.Stats;

    public interface IWeapon
    {
        string Name { get; }

        Rarity Rarity { get; }

        BasicStats BasicStats { get; }

        MagicStats MagicStats { get; }

        void AddGem(IGem gem, int indexOfSocket);

        void RemoveGem(int indexOfSocket);

        void SetTotalStatsValue();
    }
}
