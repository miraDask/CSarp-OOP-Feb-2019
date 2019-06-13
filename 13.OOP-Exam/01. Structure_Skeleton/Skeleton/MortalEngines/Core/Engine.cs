using MortalEngines.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MortalEngines.Core
{
    public class Engine : IEngine
    {
        private MachinesManager manager;

        public Engine()
        {
            this.manager = new MachinesManager();       
        }

        public void Run()
        {
            while (true)
            {
                var input = Console.ReadLine();

                if (input == "Quit")
                {
                    break;
                }

                var commandLine = input.Split();

                var command = commandLine[0];
                string name = string.Empty;
                double attack = 0;
                double deff = 0;



                try
                {
                    if (command == "HirePilot")
                    {
                        name = commandLine[1];

                        Console.WriteLine(this.manager.HirePilot(name));
                    }
                    else if(command == "PilotReport")
                    {
                        name = commandLine[1];

                        Console.WriteLine(this.manager.PilotReport(name));
                    }
                    else if(command == "ManufactureTank")
                    {
                        //•	ManufactureTank { name}
                        //                { attack}
                        //                { defense}

                        name = commandLine[1];
                         attack = double.Parse(commandLine[2]);
                         deff = double.Parse(commandLine[3]);
                        Console.WriteLine(this.manager.ManufactureTank(name, attack, deff));
                    }
                    else if(command == "ManufactureFighter")
                    {
                        name = commandLine[1];
                        attack = double.Parse(commandLine[2]);
                        deff = double.Parse(commandLine[3]);
                        Console.WriteLine(this.manager.ManufactureFighter(name,attack,deff));
                    }
                    else if (command == "MachineReport")
                    {
                        name = commandLine[1];

                        Console.WriteLine(this.manager.MachineReport(name));
                    }
                    else if (command == "Attack")
                    {
                        name = commandLine[1];
                        string targetName = commandLine[2];

                        Console.WriteLine(this.manager.AttackMachines(name, targetName));
                    }
                    else if (command == "Engage")
                    {
                        name = commandLine[1];
                        string targetName = commandLine[2];
                        Console.WriteLine(this.manager.EngageMachine(name, targetName));
                    }
                    else if (command == "DefenseMode")
                    {
                        name = commandLine[1];

                        Console.WriteLine(this.manager.ToggleTankDefenseMode(name));
                    }
                    else if (command == "AggressiveMode")
                    {
                        name = commandLine[1];

                        Console.WriteLine(this.manager.ToggleFighterAggressiveMode(name));
                    }
                   
                    
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error:" + ex.Message);
                }
//                •	HirePilot { name}
//•	PilotReport { name}

//•	ManufactureFighter { name}
//                { attack}
//                { defense}
//•	MachineReport { name}
//•	AggressiveMode { name}
//•	DefenseMode { name}
//•	Engage { pilot name}
//                { machine name}
//•	Attack { attacking machine name}
//                { defending machine name}

            }
        }
    }
}
