public class PressureProvider : Provider
{
    private const int DurabilityDecreasment = 300;
    private const int EnergyOutputInreasment = 2;

    public PressureProvider(int id, double energyOutput)
        : base(id, energyOutput)
    {
        this.Durability -= DurabilityDecreasment;
        this.EnergyOutput *= EnergyOutputInreasment;
    }
}

