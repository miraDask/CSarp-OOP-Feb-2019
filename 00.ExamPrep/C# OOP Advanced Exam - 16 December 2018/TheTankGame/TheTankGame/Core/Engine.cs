namespace TheTankGame.Core
{
    using System;

    using Contracts;
    using IO.Contracts;

    public class Engine : IEngine
    {
        private bool isRunning;
        private readonly IReader reader;
        private readonly IWriter writer;
        private readonly ICommandInterpreter commandInterpreter;

        public Engine(
            IReader reader, 
            IWriter writer, 
            ICommandInterpreter commandInterpreter)
        {
            this.reader = reader;
            this.writer = writer;
            this.commandInterpreter = commandInterpreter;

            this.isRunning = false;
        }

        public void Run()
        {
            isRunning = true;

            while (isRunning)
            {
                string[] commandLine = this.reader.ReadLine().Split();

                if (commandLine[0] == "Terminate")
                {
                    isRunning = false;
                }

                writer.WriteLine( this.commandInterpreter.ProcessInput(commandLine));
            }
        }
    }
}