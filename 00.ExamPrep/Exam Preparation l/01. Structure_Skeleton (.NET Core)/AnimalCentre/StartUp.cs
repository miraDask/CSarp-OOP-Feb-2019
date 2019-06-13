using AnimalCentre.Core;
using AnimalCentre.Factories.Contracts;
using System;

namespace AnimalCentre
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            ICommandInterpreter commandInterpreter = new CommandInterpreter(); 
            var engine = new Engine(commandInterpreter);
            engine.Run();
        }
    }
}
