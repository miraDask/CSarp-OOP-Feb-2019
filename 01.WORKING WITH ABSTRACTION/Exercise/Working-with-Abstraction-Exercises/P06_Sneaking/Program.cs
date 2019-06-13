using System;

namespace P06_Sneaking
{
    class Sneaking
    {
        static void Main()
        {
            var rows = int.Parse(Console.ReadLine());
            var matrix = FillTheRoom(rows);
            var samPosition = GetSamPosition(matrix);

            var directions = Console.ReadLine().ToCharArray();

            for (int i = 0; i < directions.Length; i++)
            {
                
                matrix = MoveEnemies(matrix);

                var enemyPosition = GetEnemyPosition(matrix, samPosition.Row);

                bool samIsDead = GetInformation(samPosition, enemyPosition, matrix);

                if (samIsDead)
                {
                    matrix[samPosition.Row][samPosition.Col] = 'X';

                    Console.WriteLine($"Sam died at {samPosition.Row}, {samPosition.Col}");
                    break;
                }
               
                matrix[samPosition.Row][samPosition.Col] = '.';

                var currentDirectionForSamToMove = directions[i];

                samPosition = GetNewPosition(currentDirectionForSamToMove,samPosition);
                
                matrix[samPosition.Row][samPosition.Col] = 'S';

                enemyPosition = GetEnemyPosition(matrix, samPosition.Row);


                if (EnemyIsDead(enemyPosition,samPosition,matrix))
                {
                    matrix[enemyPosition.Row][enemyPosition.Col] = 'X';

                    Console.WriteLine("Nikoladze killed!");
                    break;
                }
            }

            PrintMatrix(matrix);
        }

        private static bool EnemyIsDead(Position enemyPosition, Position samPosition, char[][] matrix)
        {
            return matrix[enemyPosition.Row][enemyPosition.Col] == 'N'
                     && samPosition.Row == enemyPosition.Row;
        }

        private static Position GetNewPosition(char currentDirectionForSamToMove, Position samPosition)
        {

            switch (currentDirectionForSamToMove)
            {
                case 'U':
                    samPosition.Row--;
                    break;
                case 'D':
                    samPosition.Row++;
                    break;
                case 'L':
                    samPosition.Col--;
                    break;
                case 'R':
                    samPosition.Col++;
                    break;
                default:
                    break;
            }

            return samPosition;
        }

        private static void PrintMatrix(char[][] matrix)
        {
            foreach (var row in matrix)
            {
                Console.WriteLine(string.Join("", row));
            }
        }

        private static bool GetInformation(Position samPosition, Position enemyPosition, char[][] matrix)
        {
            bool samIsInFrontOfEnemy = samPosition.Col < enemyPosition.Col
                       && matrix[enemyPosition.Row][enemyPosition.Col] == 'd'
                       && enemyPosition.Row == samPosition.Row;
            bool samIsInAfterEnemy = enemyPosition.Col < samPosition.Col
                      && matrix[enemyPosition.Row][enemyPosition.Col] == 'b'
                      && enemyPosition.Row == samPosition.Row;

            return samIsInFrontOfEnemy || samIsInAfterEnemy;
        }

        private static Position GetEnemyPosition(char[][] matrix, int samRow)
        {
            var position = new Position();

            for (int j = 0; j < matrix[samRow].Length; j++)
            {
                if (matrix[samRow][j] != '.' && matrix[samRow][j] != 'S')
                {
                    position.Row = samRow;
                    position.Col = j;
                }
            }

            return position;
        }

        private static char[][] MoveEnemies(char[][] matrix)
        {
            for (int row = 0; row < matrix.Length; row++)
            {
                for (int col = 0; col < matrix[row].Length; col++)
                {
                    if (matrix[row][col] == 'b')
                    {
                        if (row >= 0 && row < matrix.Length && col + 1 >= 0 && col + 1 < matrix[row].Length)
                        {
                            matrix[row][col] = '.';
                            matrix[row][col + 1] = 'b';
                            col++;
                        }
                        else
                        {
                            matrix[row][col] = 'd';
                        }
                    }
                    else if (matrix[row][col] == 'd')
                    {
                        if (row >= 0 && row < matrix.Length && col - 1 >= 0 && col - 1 < matrix[row].Length)
                        {
                            matrix[row][col] = '.';
                            matrix[row][col - 1] = 'd';
                        }
                        else
                        {
                            matrix[row][col] = 'b';
                        }
                    }
                }
            }

            return matrix;
        }

        private static Position GetSamPosition(char[][] matrix)
        {
            var samPosition = new Position();

            for (int row = 0; row < matrix.Length; row++)
            {
                for (int col = 0; col < matrix[row].Length; col++)
                {
                    if (matrix[row][col] == 'S')
                    {
                        samPosition.Row = row;
                        samPosition.Col = col;
                    }
                }
            }

            return samPosition;
        }

        private static char[][] FillTheRoom(int rows)
        {
            var matrix = new char[rows][];

            for (int row = 0; row < rows; row++)
            {
                var input = Console.ReadLine().ToCharArray();
                matrix[row] = new char[input.Length];
                for (int col = 0; col < input.Length; col++)
                {
                    matrix[row][col] = input[col];
                }
            }

            return matrix;
        }
    }
}
