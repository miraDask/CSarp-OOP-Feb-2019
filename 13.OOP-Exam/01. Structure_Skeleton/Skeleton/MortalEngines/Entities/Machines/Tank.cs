using MortalEngines.Entities.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace MortalEngines.Entities.Machines
{
    public class Tank : BaseMachine
    {
        private const double InitialHealthPoints = 100;

        public Tank(string name, double attackPoints, double defensePoints)
            : base(name, attackPoints, defensePoints, InitialHealthPoints)
        {
            this.DefenseMode = false;
            ToggleDefenseMode();
        }

        public bool DefenseMode { get; private set; }

        //TODO ???
        public void ToggleDefenseMode()
        {
            //Flips DefenseMode(true-> false or false-> true).
            //When DefenseMode is activated, attack points are
            //    decreased with 40 and defense points are increased with 30, otherwise(DefenseMode is deactivated)
            //    attack points are increased with 40 and defense points are decreased with 30.

            if (this.DefenseMode == true)
            {
                this.DefenseMode = false;
                this.AttackPoints += 40;
                this.DefensePoints -= 30;
            }
            else
            {
                this.DefenseMode = true;
                this.AttackPoints -= 40;
                this.DefensePoints += 30;
            }
        }

        public override string ToString()
        {
            var modeInfo = this.DefenseMode == true ? "ON" : "OFF";
            return base.ToString() + Environment.NewLine + $" *Defense: {modeInfo}";
        }
    }
}
