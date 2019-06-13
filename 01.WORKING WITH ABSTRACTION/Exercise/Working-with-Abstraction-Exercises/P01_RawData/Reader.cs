namespace P01_RawData
{
    using System;

    public class Reader : IDataReader
    {
        public string Read()
        {
            return Console.ReadLine();
        }
    }
}
