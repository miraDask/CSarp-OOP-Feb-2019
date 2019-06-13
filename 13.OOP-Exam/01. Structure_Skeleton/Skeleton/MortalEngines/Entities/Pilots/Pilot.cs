using MortalEngines.Entities.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace MortalEngines.Entities.Pilots
{
    public class Pilot : IPilot
    {
        private string name;
        private List<IMachine> machines;

        public Pilot(string name)
        {
            this.Name = name;
            this.machines = new List<IMachine>();
        }

        public string Name
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value) || string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Pilot name cannot be null or empty string.");
                }

                this.name = value;
            }
        }

        public void AddMachine(IMachine machine)
        {
            if (machine == null)
            {
                throw new NullReferenceException("Null machine cannot be added to the pilot.");
            }

            this.machines.Add(machine);
        }

        public string Report()
        {

            StringBuilder result = new StringBuilder();
            var machinesCount = this.machines.Count;

            result.AppendLine($"{this.Name} - {machinesCount} machines");

            if (machinesCount > 0)
            {
                foreach (var machine in machines)
                {
                    result.AppendLine(machine.ToString());
                }
            }

            return result.ToString().TrimEnd();
        }
    }
}
