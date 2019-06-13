using SimpleSnake.GameObjects.Contracts;
using System;
using System.Linq;
using System.Reflection;

namespace SimpleSnake.GameObjects.Foods
{
    public class FactoryFood
    {
        private Random random;

        public FactoryFood()
        {
            this.random = new Random();
        }

        public IFood GenerateRandomFood(int boardWidth, int boardHeight)
        {
           
            var foodTypes = Assembly
                .GetExecutingAssembly()
                .GetTypes()
                .Where(x => x.IsSubclassOf(typeof(Food)))
                .ToList();

            Type randomFoodType = foodTypes[random.Next(0, foodTypes.Count)];

            var randomX = random.Next(3, boardWidth - 3);
            var randomY = random.Next(3, boardHeight - 3);
            var randomCoordinate = new Coordinate(randomX, randomY);

            return (IFood)Activator.CreateInstance(randomFoodType, randomCoordinate);
        }
    }
}
