namespace P07.InfernoInfinity.Models.Gems
{
    using P07.InfernoInfinity.Models.Contracts;

    public class Amethyst : Gem
    {
        private const int StrengthIncreasment = 2;
        private const int AgilityIncreasment = 8;
        private const int VitalityIncreasment = 4;

        public Amethyst(Clarity clarity)
            : base(clarity)
        {
            this.StrengthIncreasmentValue = StrengthIncreasment;
            this.AgilityIncreasmentValue = AgilityIncreasment;
            this.VitalityIncreasmentValue = VitalityIncreasment;
        }
    }
}
