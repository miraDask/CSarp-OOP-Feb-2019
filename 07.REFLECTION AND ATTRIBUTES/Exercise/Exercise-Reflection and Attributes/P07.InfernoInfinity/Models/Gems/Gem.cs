namespace P07.InfernoInfinity.Models.Gems
{
    using P07.InfernoInfinity.Models.Contracts;

    public abstract class Gem : IGem
    {
        private Clarity clarity;

        public Gem(Clarity clarity)
        {
            this.Clarity = clarity;
        }

        public Clarity Clarity { get; protected set; }

        public int StrengthIncreasmentValue { get; protected set; }

        public int AgilityIncreasmentValue { get; protected set; }

        public int VitalityIncreasmentValue { get; protected set; }
    }
}
