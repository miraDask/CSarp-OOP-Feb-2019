namespace p01.RhombusOfStars
{
    using System;

    public class Program
    {
        public static void Main()
        {
            int number = int.Parse(Console.ReadLine());

            PrintFirstPart(number);
            PrintSecondPart(number);
           
        }

        private static void PrintSecondPart(int number)
        {
            int spacesCount = 1;

            for (int i = number - 1; i >= 0; i--)
            {
                PrintRow(number, spacesCount, i, "second");
                spacesCount++;
            }
        }

        private static void PrintFirstPart(int number)
        {
            int spacesCount = number;

            for (int i = 0; i < number; i++)
            {
                PrintRow(number,spacesCount,i,"first");
                spacesCount--;
            }
        }

        private static void PrintRow(int number, int spacesCount, int i, string row)
        {
            string spaces = string.Empty;
            string stars = string.Empty;

            if (row == "first")
            {
                stars = new string('*', i + 1);
                spaces = new string(' ', spacesCount);
            }
            else
            {
                stars = new string('*', i );
                spaces = new string(' ', spacesCount + 1);
            }

            char[] starsToArray = stars.ToCharArray();
            Console.WriteLine($"{spaces}{string.Join(" ", starsToArray)}{spaces}");
        }
    }
}
