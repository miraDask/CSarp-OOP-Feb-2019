namespace P07.InfernoInfinity.Models.Gems
{
    using P07.InfernoInfinity.Models.Contracts;

    public class Ruby : Gem
    {
        private const int StrengthIncreasment = 7;
        private const int AgilityIncreasment = 2;
        private const int VitalityIncreasment = 5;
        //private int strengthIncreasmentValue;
        //private int agilityIncreasmentValue;
        //private int vitalityIncreasmentValue;

        public Ruby(Clarity clarity)
            : base(clarity)
        {
            this.StrengthIncreasmentValue = StrengthIncreasment;
            this.AgilityIncreasmentValue = AgilityIncreasment;
            this.VitalityIncreasmentValue = VitalityIncreasment;
        }

        //public override int StrengthIncreasmentValue
        //{
        //    get => this.strengthIncreasmentValue;
        //    protected set => this.strengthIncreasmentValue = StrengthIncreasment;
        //}

        //public override int AgilityIncreasmentValue
        //{
        //    get => this.agilityIncreasmentValue;
        //    protected set => this.agilityIncreasmentValue = AgilityIncreasment;
        //}

        //public override int VitalityIncreasmentValue
        //{
        //    get => this.vitalityIncreasmentValue;
        //    protected set => this.vitalityIncreasmentValue = VitalityIncreasment;
        //}
    }
}
