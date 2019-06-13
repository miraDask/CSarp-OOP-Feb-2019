namespace P07.InfernoInfinity.Core
{
    using P07.InfernoInfinity.Core.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Engine : IRunnable
    {
        private ICommandInterpreter commandInterpreter;

        public Engine(ICommandInterpreter commandInterpreter)
        {
            this.commandInterpreter = commandInterpreter;
        }

        public void Run()
        {
            while (true)
            {
                var input = Console.ReadLine();

                if (input == "END")
                {
                    break;
                }

                var data = input.Split(';');

                var command = this.commandInterpreter.GetCommand(data);
                command.Execute();
            }
        }
    }
}
