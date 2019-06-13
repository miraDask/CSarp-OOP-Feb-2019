namespace p04.HotelReservation
{
    using System;

    class Startup
    {
        static void Main()
        {
            string[] holidayInfo = Console.ReadLine().Split();

            decimal pricePerDay = decimal.Parse(holidayInfo[0]);
            int numberOfDays = int.Parse(holidayInfo[1]);
            Season season = (Season)Enum.Parse(typeof(Season), holidayInfo[2]);
            DiscountType discount = DiscountType.None;

            if (holidayInfo.Length == 4)
            {
                discount = (DiscountType)Enum.Parse(typeof(DiscountType), holidayInfo[3]);
            }

            PriceCalculator calculator = new PriceCalculator();
            decimal totalPriceForHoliday =  calculator.Calculate(pricePerDay,numberOfDays, season, discount);

            Console.WriteLine($"{totalPriceForHoliday:f2}");
        }
    }
}
