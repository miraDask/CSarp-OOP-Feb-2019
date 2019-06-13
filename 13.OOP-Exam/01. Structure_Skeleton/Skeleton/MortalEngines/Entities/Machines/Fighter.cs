using System;
using System.Collections.Generic;
using System.Text;

namespace MortalEngines.Entities.Machines
{
    public class Fighter : BaseMachine
    {
        private const double InitialHealthPoints = 200;

        public Fighter(string name, double attackPoints, double defensePoints)
            : base(name, attackPoints, defensePoints, InitialHealthPoints)
        {
            this.AggressiveMode = false;
            ToggleAggressiveMode();
        }

        public bool AggressiveMode { get; private set; }

        // TODO NOT SURE
        public void ToggleAggressiveMode()
        {
            if (this.AggressiveMode == true)
            {
                this.AggressiveMode = false;
                this.AttackPoints -= 50;
                this.DefensePoints += 25;
            }
            else
            {
                this.AggressiveMode = true;
                this.AttackPoints += 50;
                this.DefensePoints -= 25;
            }
        }

        public override string ToString()
        {
            var modeInfo = this.AggressiveMode == true ? "ON" : "OFF";
            return base.ToString() + Environment.NewLine + $" *Aggressive: {modeInfo}";
        }
    }
}
