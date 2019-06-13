namespace MuOnline.Core.Writers
{
    using Core.Contracts;
    using System;

    public class ConsoleWriter : IWriter
    {
        public void Write(string result)
        {
            Console.Write(result);
        }

        public void WriteLine(string result)
        {
            Console.WriteLine(result);
        }
    }
}
