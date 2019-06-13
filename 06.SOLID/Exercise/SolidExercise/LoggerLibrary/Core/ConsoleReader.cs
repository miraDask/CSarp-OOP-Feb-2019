namespace LoggerLibrary.Core
{
    using LoggerLibrary.Core.Contracts;
    using System;

    public class ConsoleReader : IReader
    {
        public string Read()
        {
            return Console.ReadLine();
        }
    }
}
