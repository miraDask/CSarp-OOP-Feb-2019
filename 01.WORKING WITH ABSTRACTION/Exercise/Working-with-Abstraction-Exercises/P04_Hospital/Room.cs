namespace P04_Hospital
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Room
    {
        private int capacity;

        public Room()
        {
            this.Beds = new List<string>();
            this.capacity = 3;
        }

        public  List<string> Beds { get; set; }
        

        public bool AddPatient(string name)
        {
            if (this.Beds.Count < this.capacity)
            {
                this.Beds.Add(name);
                return true;
            }

            return false;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var bed in this.Beds)
            {
                sb.AppendLine(bed);
            }

            return sb.ToString().TrimEnd();
        }

        public void OrderByName()
        {
            this.Beds = this.Beds.OrderBy(x => x).ToList();
        }
    }
}
