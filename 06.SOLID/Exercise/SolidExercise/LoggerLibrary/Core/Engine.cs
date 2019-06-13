namespace LoggerLibrary.Core
{
    using Core.Contracts;
    using System.Collections.Generic;

    public class Engine : IEngine
    {
        private IReader reader;
        private IWriter writer;
        private CommandInterpreter commandInterpreter;
        private List<string[]> reportCollection;
       
        public Engine()
        {
            this.reader = new ConsoleReader();
            this.writer = new ConsoleWriter();
            this.commandInterpreter = new CommandInterpreter();
            this.reportCollection = new List<string[]>();
        }

        public void Run()
        {
            int appendersCount = int.Parse(reader.Read());

            for (int i = 0; i < appendersCount; i++)
            {
                string[] appenderArgs = reader.Read().Split();
                commandInterpreter.AddAppender(appenderArgs); 
            }

            while (true)
            {
                string input = reader.Read();

                if (input == "END")
                {
                    break;
                }

                string[] currentReportArgs = input.Split("|");
                reportCollection.Add(currentReportArgs);
            }

            foreach (var report in reportCollection)
            {
                commandInterpreter.AddReport(report);

            }

            this.writer.WriteLine(this.commandInterpreter.WriteInfo());
        }
    }
}
