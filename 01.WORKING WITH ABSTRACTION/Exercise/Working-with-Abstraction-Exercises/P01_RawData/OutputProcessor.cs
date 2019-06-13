namespace P01_RawData
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class OutputProcessor
    {
        private Reader reader;
        private Writer writer;
        private List<Car> cars;

        public OutputProcessor(Reader reader, Writer writer,List<Car> cars)
        {
            this.reader = reader;
            this.writer = writer;
            this.cars = cars;
        }

        public void Run()
        {
            string command = this.reader.Read();

            if (command == "fragile")
            {
                List<string> fragile = cars
                    .Where(x => x.Cargo.Type == "fragile" && x.Tires.Any(y => y.Pressure < 1))
                    .Select(x => x.Model)
                    .ToList();

                this.writer.Write(string.Join(Environment.NewLine, fragile));
            }
            else
            {
                List<string> flamable = cars
                    .Where(x => x.Cargo.Type == "flamable" && x.Engine.Power > 250)
                    .Select(x => x.Model)
                    .ToList();

                this.writer.Write(string.Join(Environment.NewLine, flamable));
            }
        }
    }
}
