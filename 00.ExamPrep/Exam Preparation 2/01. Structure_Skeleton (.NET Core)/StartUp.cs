using SoftUniRestaurant.Core;
using System;
using System.Text;

namespace SoftUniRestaurant
{
    public class StartUp
    {
        public static void Main()
        {
            var controller = new RestaurantController();
            var result = new StringBuilder();

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "END")
                {
                    result.AppendLine(controller.GetSummary());
                    break;
                }

                var commandLine = input.Split();

                var command = commandLine[0];
                string type = string.Empty;
                string name = string.Empty;
                string brand = string.Empty;
                int number = 0;

                try
                {
                    switch (command)
                    {
                        case "AddFood":
                            type = commandLine[1];
                            name = commandLine[2];
                            decimal price = decimal.Parse(commandLine[3]);

                            result.AppendLine(controller.AddFood(type, name, price));
                            break;
                        case "AddDrink":
                            type = commandLine[1];
                            name = commandLine[2];
                            var servingSize = int.Parse(commandLine[3]);
                            brand = commandLine[4];

                            result.AppendLine(controller.AddDrink(type, name, servingSize, brand));
                            break;

                        case "AddTable":
                            type = commandLine[1];
                            number = int.Parse(commandLine[2]);
                            var capacity = int.Parse(commandLine[3]);
                            result.AppendLine(controller.AddTable(type, number, capacity));
                            break;
                        case "ReserveTable":
                            var numberOfPeople = int.Parse(commandLine[1]);
                            result.AppendLine(controller.ReserveTable(numberOfPeople));
                            break;
                        case "OrderFood":
                            number = int.Parse(commandLine[1]);
                            name = commandLine[2];
                            result.AppendLine(controller.OrderFood(number, name));
                            break;
                        case "OrderDrink":
                            number = int.Parse(commandLine[1]);
                            name = commandLine[2];
                            brand = commandLine[3];

                            result.AppendLine(controller.OrderDrink(number, name, brand));
                            break;
                        case "LeaveTable":
                            number = int.Parse(commandLine[1]);

                            result.AppendLine(controller.LeaveTable(number));
                            break;
                        case "GetFreeTablesInfo":
                            result.AppendLine(controller.GetFreeTablesInfo());
                            break;
                        case "GetOccupiedTablesInfo":
                            result.AppendLine(controller.GetOccupiedTablesInfo());
                            break;
                    }
                }
                catch (Exception ex)
                {
                    result.AppendLine(ex.InnerException.Message);
                    continue;
                }
            }

            Console.Write(result);
        }
    }
}
