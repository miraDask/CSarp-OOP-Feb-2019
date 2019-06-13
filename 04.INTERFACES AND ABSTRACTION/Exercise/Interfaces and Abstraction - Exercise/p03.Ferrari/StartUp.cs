namespace p03.Ferrari
{
    using System;

    class StartUp
    {
        static void Main()
        {
            string driverName = Console.ReadLine();

            ICar ferrari = new Ferrari(driverName);

            Console.WriteLine(ferrari.ToString());
        }
    }
}
