namespace P03_JediGalaxy
{
    using System;
    using System.Linq;

    public class Startup
    {
        static void Main()
        {
            int[] dimestions = Console.ReadLine()
                .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int rowsLenght = dimestions[0];
            int colsLenght = dimestions[1];

            int[,] matrix = FillTheMatrix(rowsLenght,colsLenght);

            string command = Console.ReadLine();

            long sum = 0;

            while (command != "Let the Force be with you")
            {
                int[] playerPosition = command.
                    Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                int[] enemyPosition = Console.ReadLine()
                    .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                Enemy enemy = new Enemy
                {
                    Row = enemyPosition[0],
                    Col = enemyPosition[1]
                };

                bool positionIsInMatrix = true;

                while (enemy.Row >= 0 && enemy.Col >= 0)
                {
                    positionIsInMatrix = CheckPosition(enemy.Row,enemy.Col,matrix);

                    if (positionIsInMatrix)
                    {
                        matrix[enemy.Row, enemy.Col] = 0;
                    }

                    enemy.Row--;
                    enemy.Col--;
                }

                Player player = new Player
                {
                    Row = playerPosition[0],
                    Col = playerPosition[1]
                };

                while (player.Row >= 0 && player.Col < matrix.GetLength(1))
                {
                    positionIsInMatrix = CheckPosition(player.Row, player.Col, matrix);

                    if (positionIsInMatrix)
                    {
                        sum += matrix[player.Row, player.Col];
                    }

                    player.Col++;
                    player.Row--;
                }

                command = Console.ReadLine();
            }

            Console.WriteLine(sum);

        }

        private static bool CheckPosition(int row, int col, int[,] matrix)
        {
            return row >= 0 && row < matrix.GetLength(0) && col >= 0 && col < matrix.GetLength(1);
        }

        private static int[,] FillTheMatrix(int rowsLenght, int colsLenght)
        {
            int[,] matrix = new int[rowsLenght, colsLenght];

            int value = 0;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = value++;
                }
            }

            return matrix;
        }
    }
}
