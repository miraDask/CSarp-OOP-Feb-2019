using AnimalCentre.Factories.Contracts;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace AnimalCentre.Core
{
    public class Engine
    {
        private bool isRunning;
        private ICommandInterpreter commandInterpreter;

        public Engine(ICommandInterpreter commandInterpreter)
        {
            this.commandInterpreter = commandInterpreter;
            this.isRunning = false;
        }

        public void Run()
        {
            this.isRunning = true;

            while (isRunning)
            {
                var input = Console.ReadLine();

                if (input == "End")
                {
                    this.isRunning = false;
                }

                var commandLine = input.Split();

                string result = string.Empty;

                try
                {
                    result = this.commandInterpreter.Read(commandLine);
                }
                catch (InvalidOperationException ioex)
                {
                    Console.WriteLine("InvalidOperationException: " + ioex.Message);
                    continue;
                }
                catch(ArgumentException aex)
                {
                    Console.WriteLine("ArgumentException: " + aex.Message);
                    continue;
                }
                catch(TargetInvocationException tex)
                {

                    Console.WriteLine($"{tex.InnerException.InnerException.GetType().Name}: "
                        + tex.InnerException.InnerException.Message);
                    continue;
                }

                Console.WriteLine(result);
            }
        }
    }
}
