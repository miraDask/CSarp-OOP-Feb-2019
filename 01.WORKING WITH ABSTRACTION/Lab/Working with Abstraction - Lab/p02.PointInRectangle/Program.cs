namespace p02.PointInRectangle
{
    using System;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            int[] rectangleCoordinates = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int topLeftX = rectangleCoordinates[0];
            int topLeftY = rectangleCoordinates[1];
            int bottomRightX = rectangleCoordinates[2];
            int bottomRightY = rectangleCoordinates[3];

            Rectangle rectangle = new Rectangle(topLeftX,topLeftY, bottomRightX,bottomRightY);

            int inputCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < inputCount; i++)
            {
                int[] pointCoordinates = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

                int x = pointCoordinates[0];
                int y = pointCoordinates[1];

                Point point = new Point(x, y);

                Console.WriteLine(rectangle.Contains(point));
            }
        }
    }
}
