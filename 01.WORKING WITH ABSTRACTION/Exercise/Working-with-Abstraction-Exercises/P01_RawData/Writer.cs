namespace P01_RawData
{
    public class Writer : IDataWriter
    {
        public void Write(object obj)
        {
            System.Console.WriteLine(obj);
        }
    }
}
