namespace p08.MilitaryElite
{
    using p08.MilitaryElite.Interfaces;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Engineer : SpecialisedSoldier, IEngineer
    {

        public Engineer(string id, string firstName, string lastName, decimal salary, string corps, List<Repair> repairs) 
            : base(id, firstName, lastName, salary, corps)
        {
            this.Repairs = repairs;
        }

        public List<Repair> Repairs { get; private set; }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            result.AppendLine(base.ToString());
            result.AppendLine("Repairs:");

            if (this.Repairs.Any())
            {
                foreach (var repair in this.Repairs)
                {
                    result.AppendLine(repair.ToString());
                }
            }

            return result.ToString().TrimEnd();
        }
    }
}
