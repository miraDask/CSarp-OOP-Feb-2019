namespace P04_Hospital
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Doctor
    {
        public Doctor(string name)
        {
            this.Name = name;
            this.Patients = new List<string>();
        }

        public string Name { get; set; }

        public List<string> Patients { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var patient in this.Patients.OrderBy(x => x))
            {
                sb.AppendLine(patient);
            }

            return sb.ToString().TrimEnd();
        }
    }
}
