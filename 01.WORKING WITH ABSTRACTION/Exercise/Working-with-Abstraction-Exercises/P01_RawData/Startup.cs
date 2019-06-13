namespace P01_RawData
{
    using System.Collections.Generic;

    public class RawData
    {
        public static void Main(string[] args)
        {
            Reader reader = new Reader();
            Writer writer = new Writer();
            InputProcessor input = new InputProcessor(reader);
            List<Car> cars = input.GetCollection();
            OutputProcessor output = new OutputProcessor(reader,writer,cars);
            output.Run();

        }
    }
}
