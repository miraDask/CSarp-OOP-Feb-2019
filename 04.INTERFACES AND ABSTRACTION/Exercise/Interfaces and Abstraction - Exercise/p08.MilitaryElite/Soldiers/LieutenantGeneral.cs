namespace p08.MilitaryElite
{
    using p08.MilitaryElite.Interfaces;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class LieutenantGeneral : Private, ILieutenantGeneral
    {
        public LieutenantGeneral(string id, string firstName, string lastName, decimal salary, List<Private> privates )
            : base(id, firstName, lastName, salary)
        {
            this.Privates = privates;
        }

        public List<Private> Privates { get; private set; }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            result.AppendLine(base.ToString());
            result.AppendLine("Privates:");

            if (this.Privates.Any())
            {
                foreach (var @private in this.Privates)
                {
                    result.AppendLine("  " + @private.ToString());
                }
            }
            
            return result.ToString().TrimEnd();
        }
    }
}
