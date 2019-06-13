namespace MortalEngines.Core
{
    using Contracts;
    using MortalEngines.Common;
    using MortalEngines.Entities.Contracts;
    using MortalEngines.Entities.Machines;
    using MortalEngines.Entities.Machines.Factories;
    using MortalEngines.Entities.Pilots;
    using System;
    using System.Collections.Generic;

    public class MachinesManager : IMachinesManager
    {
        private PilotFactory pilotFactory;
        private MachineFactory machineFactory;
        private Dictionary<string, IPilot> pilots;
        private Dictionary<string, IMachine> machines;
        private OutputMessages messages;

        public MachinesManager()
        {
            this.pilotFactory = new PilotFactory();
            this.machineFactory = new MachineFactory();
            this.pilots = new Dictionary<string, IPilot>();
            this.machines = new Dictionary<string, IMachine>();
            this.messages = new OutputMessages();
        }
        public string HirePilot(string name)
        {
            /*Parameters
•	Name – string
Functionality
Creates a pilot with the provided name and adds him/her to the collection of pilots. The method should return one of the following messages:
•	"Pilot {name} hired"
•	"Pilot {name} is hired already" - if the pilot with the given name already exists and  you should not create a pilot. 
*/
            if (this.pilots.ContainsKey(name))
            {
                return string.Format(OutputMessages.PilotExists, name);
            }
            else
            {
                this.pilots[name] = this.pilotFactory.GetPilot(name);
                return string.Format(OutputMessages.PilotHired, name);
            }
        }

        public string ManufactureTank(string name, double attackPoints, double defensePoints)
        {
            /*Parameters
•	Name - string
•	Attack – double
•	Defense - double
Functionality
Creates a tank with given name, attack and defense points. The method should return one of the following messages:
•	"Tank {name} manufactured - attack: {attack}; defense: {defense}"
•	"Machine {name} is manufactured already" – if tank with the given name exists and you should not create a tank.
*/
            if (this.machines.ContainsKey(name))
            {
                return string.Format(OutputMessages.MachineExists, name);
            }
            else
            {
                var tank = this.machineFactory.GetMachine("Tank", name, attackPoints, defensePoints);
                this.machines[name] = tank;
                return string.Format(OutputMessages.TankManufactured, name, tank.AttackPoints, tank.DefensePoints);
            }

        }

        public string ManufactureFighter(string name, double attackPoints, double defensePoints)
        {
            //            Creates a fighter with given name, attack and defense points.Duplicate
            //names are not allowed.As a result, the command returns one of the following messages:
            //•	"Fighter {name} manufactured - attack: {attack}; defense: {defense}; aggressive: ON"
            //•	"Machine {name} is manufactured already"
            //– if fighter with the given name exists and you should not create a figher. 

            if (this.machines.ContainsKey(name))
            {
                return string.Format(OutputMessages.MachineExists, name);
            }
            else
            {
                Fighter fighter = (Fighter)this.machineFactory.GetMachine("Fighter", name, attackPoints, defensePoints);
                this.machines[name] = fighter;
                return string.Format(OutputMessages.FighterManufactured, name, fighter.AttackPoints, fighter.DefensePoints, "ON");
            }
        }

        public string EngageMachine(string selectedPilotName, string selectedMachineName)
        {
            //Searches for a pilot and machine by given names.If both exist and the machine is not occupied
            //    , add the machine to the pilot's list of machines and set the machine's
            //    pilot.As a result, the command returns one of the following messages: 
            //            •	"Pilot {pilot name} could not be found"
            //•	"Machine {machine name} could not be found"
            //•	"Machine {machine name} is already occupied"
            //•	"Pilot {pilot name} engaged machine {machine name}"

            IPilot pilot = null;

            if (pilots.ContainsKey(selectedPilotName))
            {
                pilot = this.pilots[selectedPilotName];
            }
            else
            {
                return string.Format(OutputMessages.PilotNotFound, selectedPilotName);
            }

            IMachine machine = null;

            if (machines.ContainsKey(selectedMachineName))
            {
                machine = this.machines[selectedMachineName];
            }
            else
            {
                return string.Format(OutputMessages.MachineNotFound, selectedMachineName);
            }

            if (machine.Pilot != null)
            {
                return string.Format(OutputMessages.MachineHasPilotAlready, selectedMachineName);
            }

            machine.Pilot = pilot;
            pilot.AddMachine(machine);

            return string.Format(OutputMessages.MachineEngaged, selectedPilotName, selectedMachineName);

        }

        public string AttackMachines(string attackingMachineName, string defendingMachineName)
        {
            IMachine attacker = null;

            if (machines.ContainsKey(attackingMachineName))
            {
                attacker = this.machines[attackingMachineName];
            }
            else
            {
                return string.Format(OutputMessages.MachineNotFound, attackingMachineName);
            }

            if (attacker.HealthPoints == 0)
            {
                return string.Format(OutputMessages.DeadMachineCannotAttack, attackingMachineName);
            }

            IMachine target = null;

            if (machines.ContainsKey(defendingMachineName))
            {
                target = machines[defendingMachineName];
            }
            else
            {
                return string.Format(OutputMessages.MachineNotFound, defendingMachineName);
            }

            //Dead machine { name}
            //cannot attack or be attacked" –" +
            //    " if one of the machines has health equal to zero," +
            //    " the attacking machine is with priority

            if (target.HealthPoints == 0)
            {
                return string.Format(OutputMessages.DeadMachineCannotAttack, defendingMachineName);
            }

            attacker.Attack(target);


            return string.Format(OutputMessages.AttackSuccessful, target.Name, attacker.Name, target.HealthPoints);
        }

        public string PilotReport(string pilotReporting)
        {
            var pilot = this.pilots[pilotReporting];
            return pilot.Report();
        }

        public string MachineReport(string machineName)
        {
            var machine = this.machines[machineName];
            return machine.ToString();
        }

        public string ToggleFighterAggressiveMode(string fighterName)
        {
            //            Searches for fighter with given name and toggles its aggressive mode.As a result, the command returns one of the following messages:
            //•	"Fighter {name} toggled aggressive mode"
            //•	"Machine {name} could not be found" – if fighter with the given name doesn't exist  

            //TODO NOT SURE MAYBE CHECK IF IS FIGHTER TOO
            if (!this.machines.ContainsKey(fighterName))
            {
                return string.Format(OutputMessages.MachineNotFound, fighterName);
            }

            Fighter fighter = null;

            try
            {

                fighter = (Fighter)this.machines[fighterName];

            }
            catch (Exception)
            {
                return string.Format(OutputMessages.MachineNotFound, fighterName);

            }

            fighter.ToggleAggressiveMode();

            return string.Format(OutputMessages.FighterOperationSuccessful, fighterName);

        }

        public string ToggleTankDefenseMode(string tankName)
        {
            //            Functionality
            //Searches for tank with given name and toggles its defense mode.As a result, the command returns one of the following messages:
            //•	"Tank {name} toggled defense mode"
            //•	"Machine {name} could not be found" – if tank with the given name doesn't exist 

            if (!this.machines.ContainsKey(tankName))
            {
                return string.Format(OutputMessages.MachineNotFound, tankName);
            }

            Tank tank = null;

            try
            {

                tank = (Tank)this.machines[tankName];

            }
            catch (Exception)
            {
                return string.Format(OutputMessages.MachineNotFound, tankName);

            }

            tank.ToggleDefenseMode();

            return string.Format(OutputMessages.TankOperationSuccessful, tankName);
        }
    }
}