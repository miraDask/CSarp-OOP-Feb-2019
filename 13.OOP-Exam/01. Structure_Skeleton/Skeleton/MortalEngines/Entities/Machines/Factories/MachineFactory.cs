using MortalEngines.Entities.Contracts;

namespace MortalEngines.Entities.Machines.Factories
{
    public class MachineFactory
    {
        public IMachine GetMachine(string machineType, string name, double attackPoints, double defensePoints)
        {
            if (machineType =="Tank")
            {
                IMachine tank = new Tank(name, attackPoints, defensePoints);
                return tank;
            }
            else if(machineType == "Fighter")
            {
                IMachine fighter = new Fighter(name, attackPoints, defensePoints);
                return fighter;
            }
            else
	        {
                return null;
            }
        }

    }
}
