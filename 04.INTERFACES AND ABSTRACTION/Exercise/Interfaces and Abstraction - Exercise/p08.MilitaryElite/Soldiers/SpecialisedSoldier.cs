namespace p08.MilitaryElite
{
    using p08.MilitaryElite.Interfaces;
    using System;
    using System.Text;

    public abstract class SpecialisedSoldier : Private , ISpecialisedSoldier
    {
        private const string FirstCorpsNames = "Marines";
        private const string SecondCorpsNames = "Airforces";
        private string corps;

        public SpecialisedSoldier(string id, string firstName, string lastName, decimal salary, string corps)
            : base(id, firstName, lastName, salary)
        {
            this.Corps = corps;
        }

        public string Corps
        {
            get => this.corps;
            protected set
            {
                if (value != FirstCorpsNames && value != SecondCorpsNames)
                {
                    throw new ArgumentException();
                }

                this.corps = value;
            }
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            result.AppendLine(base.ToString());
            result.AppendLine($"Corps: {this.Corps}");

            return result.ToString().TrimEnd();
        }
    }
}
