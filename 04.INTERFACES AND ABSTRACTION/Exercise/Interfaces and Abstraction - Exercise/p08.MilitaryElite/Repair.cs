namespace p08.MilitaryElite
{
    public class Repair
    {
        public Repair(string partName, int workingHours)
        {
            this.PartName = partName;
            this.WorkingHours = workingHours;
        }

        public string PartName { get; private set; }

        public int WorkingHours { get; private set; }

        public override string ToString()
        {
            return $"  Part Name: {this.PartName} Hours Worked: {this.WorkingHours}";
        }
    }
}
