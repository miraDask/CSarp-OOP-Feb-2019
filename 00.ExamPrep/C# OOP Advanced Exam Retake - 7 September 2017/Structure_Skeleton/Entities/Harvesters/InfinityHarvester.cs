using System;

public class InfinityHarvester : Harvester
{
    private const int OreOutputDivider = 10;

    private double durability;

    public InfinityHarvester(int id, double oreOutput, double energyRequirement) : base(id, oreOutput, energyRequirement)
    {
        this.OreOutput /= OreOutputDivider;
    }
    //TODO - NOT SURE
    public override double Durability
    {
        get => base.Durability;
        protected set => this.durability = Math.Max(0, value); // instead value = base.Durability
    }
}