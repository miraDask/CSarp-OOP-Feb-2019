namespace P03_StudentSystem.Data
{
    using System;

    public class DataWriter : IDataWriter
    {
        public void Write(object obj)
        {
            Console.WriteLine(obj);
        }
    }
}
