namespace P07.InfernoInfinity.Models.Gems
{
    using P07.InfernoInfinity.Models.Contracts;

    public class Emerald : Gem
    {
        private const int StrengthIncreasment = 1;
        private const int AgilityIncreasment = 4;
        private const int VitalityIncreasment = 9;

        public Emerald(Clarity clarity)
            : base(clarity)
        {
            this.StrengthIncreasmentValue = StrengthIncreasment;
            this.AgilityIncreasmentValue = AgilityIncreasment;
            this.VitalityIncreasmentValue = VitalityIncreasment;
        }
    }
}
