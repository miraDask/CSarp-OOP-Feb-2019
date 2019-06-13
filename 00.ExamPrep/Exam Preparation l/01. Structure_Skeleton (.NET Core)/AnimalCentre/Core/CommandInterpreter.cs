using AnimalCentre.Factories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AnimalCentre.Core
{
    public class CommandInterpreter : ICommandInterpreter
    {
        private AnimalCentre animalCentre;

        public CommandInterpreter()
        {
            this.animalCentre = new AnimalCentre();
        }

        public string Read(string[] args)
        {
            string command = args[0];
            args = args.Skip(1).ToArray();

            string result = string.Empty;

            if (command == "End")
            {
               result = this.animalCentre.End();
            }
            else
            {
                result = (string)this.animalCentre
                             .GetType()
                             .GetMethods()
                             .FirstOrDefault(m => m.Name == command)
                             .Invoke(this.animalCentre, new object[] { args });
            }

            return result;
        }
    }
}
