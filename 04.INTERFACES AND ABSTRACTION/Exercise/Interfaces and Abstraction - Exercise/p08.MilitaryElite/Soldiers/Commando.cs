namespace p08.MilitaryElite.Soldiers
{
    using p08.MilitaryElite.Interfaces;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Commando : SpecialisedSoldier, ICommando
    {
        public Commando(string id, string firstName, string lastName, decimal salary, string corps, List<Mission> missions) 
            : base(id, firstName, lastName, salary, corps)
        {
            this.Missions = missions;
        }

        public List<Mission> Missions { get; private set; }

        public void CompleteMission(Mission mission)
        {
            if (this.Missions.Any(x => x.CodeName == mission.CodeName && x.State == "inProgress"))
            {
                mission.State = "Finished";
            }
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            result.AppendLine(base.ToString());
            result.AppendLine("Missions:");

            if (this.Missions.Any())
            {
                foreach (var mission in this.Missions)
                {
                    result.AppendLine(mission.ToString());
                }
            }

            return result.ToString().TrimEnd();
        }
    }
}
