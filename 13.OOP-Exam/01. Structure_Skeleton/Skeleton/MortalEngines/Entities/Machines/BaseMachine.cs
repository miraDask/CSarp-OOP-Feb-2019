using MortalEngines.Entities.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace MortalEngines.Entities.Machines
{
    public abstract class BaseMachine : IMachine
    {
        private string name;
        private IPilot pilot;
        private IList<string> targets;            

        protected BaseMachine(string name, double attackPoints, double defensePoints, double healthPoints)
        {
            this.Name = name;
            this.AttackPoints = attackPoints;
            this.DefensePoints = defensePoints;
            this.HealthPoints = healthPoints;
            this.targets = new List<string>();
            this.pilot = null;
        }

        public string Name
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value) || string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Machine name cannot be null or empty.");
                }
                this.name = value;
            }
        }

        public IPilot Pilot
        {
            get => this.pilot;
            set
            {
                if (value == null)
                {
                    throw new NullReferenceException("Pilot cannot be null.");
                }
                this.pilot = value;
            }
        }
        public double HealthPoints { get ; set; }

        public double AttackPoints { get; protected set; }

        public double DefensePoints { get; protected set; }

        public IList<string> Targets => this.targets;

        public void Attack(IMachine target)
        {

            /*
The machine attacks the target and decreases the target's health by the difference between the attacker's attack points and target's defense points. If the health of the target become less than zero, set it to zero.
Add the name of the target to the attacker's list of targets.
*/
            if (target == null)
            {
                throw new NullReferenceException("Target cannot be null");
            }

            target.HealthPoints -= this.AttackPoints - target.DefensePoints;

            this.targets.Add(target.Name);
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            //            "- {machine name}"
            //" *Type: {machine type name}"
            //" *Health: {machine health points}"
            //" *Attack: {machine attack points}"
            //" *Defense: {machine defense points}"
            //" *Targets: " – if there are no targets "None".Otherwise { target1},{ target2}…{ targetN}
            result.AppendLine($"- {this.name}");
            result.AppendLine($" *Type: {this.GetType().Name}");
            result.AppendLine($" *Health: {this.HealthPoints:f2}");
            result.AppendLine($" *Attack: {this.AttackPoints:f2}");
            result.AppendLine($" *Defense: {this.DefensePoints:f2}");

            var targetsInfo = targets.Count == 0 ? "None" : string.Join(',', this.targets);
            result.AppendLine($" *Targets: {targetsInfo}");

            return result.ToString().TrimEnd();
        }
    }
}
