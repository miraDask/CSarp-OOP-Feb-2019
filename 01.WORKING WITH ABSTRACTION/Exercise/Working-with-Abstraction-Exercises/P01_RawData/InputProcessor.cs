namespace P01_RawData
{
    using System;
    using System.Collections.Generic;

    public class InputProcessor
    {
        private Reader reader;

        public InputProcessor(Reader reader)
        {
            this.reader = reader;

        }

        public List<Car> GetCollection()
        {
            List<Car> cars = new List<Car>();
            int lines = int.Parse(this.reader.Read());

            for (int i = 0; i < lines; i++)
            {
                string[] parameters = this.reader.Read()
                    .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                string model = parameters[0];

                int engineSpeed = int.Parse(parameters[1]);
                int enginePower = int.Parse(parameters[2]);
                Engine engine = new Engine(engineSpeed, enginePower);

                int cargoWeight = int.Parse(parameters[3]);
                string cargoType = parameters[4];
                Cargo cargo = new Cargo(cargoWeight, cargoType);

                double firstTirePressure = double.Parse(parameters[5]);
                int firstTireAge = int.Parse(parameters[6]);
                Tire firstTire = new Tire(firstTirePressure, firstTireAge);

                double secondTirePressure = double.Parse(parameters[7]);
                int secondTireAge = int.Parse(parameters[8]);
                Tire secondTire = new Tire(secondTirePressure, secondTireAge);

                double thirdTirePressure = double.Parse(parameters[9]);
                int thirdTireAge = int.Parse(parameters[10]);
                Tire thirdTire = new Tire(thirdTirePressure, thirdTireAge);

                double fourthTirePressure = double.Parse(parameters[11]);
                int fourthTireAge = int.Parse(parameters[12]);
                Tire fourthTire = new Tire(fourthTirePressure, fourthTireAge);

                cars.Add(new Car(model,
                     engine,
                     cargo,
                     new Tire[] { firstTire, secondTire, thirdTire, fourthTire }));
            }

            return cars;
        }
    }
}
