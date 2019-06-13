namespace P07.InfernoInfinity.Models.Contracts
{
    public interface IGem
    {
        Clarity Clarity { get; }

        int StrengthIncreasmentValue { get; }

        int AgilityIncreasmentValue { get; }

        int VitalityIncreasmentValue { get; }
    }
}
