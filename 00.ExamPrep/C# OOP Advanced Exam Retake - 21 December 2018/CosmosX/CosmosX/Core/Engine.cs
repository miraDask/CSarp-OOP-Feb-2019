using CosmosX.Core.Contracts;
using CosmosX.IO.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace CosmosX.Core
{
    public class Engine : IEngine
    {
        private IReader reader;
        private IWriter writer;
        private ICommandParser commandParser;
        private bool isRunning;

        public Engine(IReader reader, IWriter writer, ICommandParser commandParser)
        {
            this.reader = reader;
            this.writer = writer;
            this.commandParser = commandParser;
            this.isRunning = false;
        }

        public void Run()
        {
            while (true)
            {
                List<string> commandLine = this.reader.ReadLine().Split().ToList();
                string resultMessage = this.commandParser.Parse(commandLine);
                writer.WriteLine(resultMessage);
                if (commandLine[0] == "Exit")
                {
                    break;
                }
            }
        }
    }
}