namespace P03_StudentSystem.Data
{
    using System;

    public class DataReader : IDataReader
    {
        public string Read()
        {
            return Console.ReadLine();
        }
    }
}
