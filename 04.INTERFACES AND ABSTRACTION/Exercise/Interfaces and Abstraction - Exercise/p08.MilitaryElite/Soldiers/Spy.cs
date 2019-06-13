namespace p08.MilitaryElite.Soldiers
{
    using p08.MilitaryElite.Interfaces;
    using System.Text;

    public class Spy : Soldier, ISpy
    {
        public Spy(string id, string firstName, string lastName, int codeNumber) 
            : base(id, firstName, lastName)
        {
            this.CodeNumber = codeNumber;
        }

        public int CodeNumber { get; private set; }

        
        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.AppendLine(base.ToString());
            result.Append($"Code Number: {this.CodeNumber}");

            return result.ToString();
        }
    }
}
