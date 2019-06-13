namespace MuOnline.Core.Readers
{
    using Core.Contracts;
    using System;

    public class ConsoleReader : IReader
    {
        public string ReadLine()
        {
           return Console.ReadLine();
        }
    }
}
