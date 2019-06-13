namespace SimpleSnake.Core
{
    using SimpleSnake.Constants;
    using SimpleSnake.GameObjects.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class DrawManager
    {
        private readonly List<ICoordinate> snakeBodyEllements;

        public DrawManager()
        {
            this.snakeBodyEllements = new List<ICoordinate>();
        }

        public void Draw(string symbol, IReadOnlyCollection<ICoordinate> coordinates)
        {
            var symbolcollection = new List<string>()
            {
                GameConstants.SnakeDownSymbol,
                GameConstants.SnakeLeftSymbol,
                GameConstants.SnakeRightSymbol,
                GameConstants.SnakeUpSymbol
            };

            foreach (var coordinate in coordinates)
            {
                if (symbolcollection.Any(x => x == symbol))
                {
                    this.snakeBodyEllements.Add(coordinate);
                }

                this.DrawOperation(symbol, coordinate);
            }
        }

        public void UndoDrawn()
        {
            this.DrawOperation(" ", this.snakeBodyEllements.First());
            this.snakeBodyEllements.Clear();
        }

        private void DrawOperation(string symbol, ICoordinate coordinate)
        {
            Console.SetCursorPosition(coordinate.CoordinateX, coordinate.CoordinateY);
            Console.Write(symbol);
        }
    }
}
