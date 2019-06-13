namespace SimpleSnake.GameObjects.Herroes
{
    using SimpleSnake.Constants;
    using SimpleSnake.Enums;
    using SimpleSnake.GameObjects.Contracts;
    using System.Collections.Generic;
    using System.Linq;

    public class Snake : IHero
    {
        private readonly List<ICoordinate> snakeBody;

        public Snake()
        {
            this.snakeBody = new List<ICoordinate>();
            this.InitializeDefaultSnake();
            this.CurrentDirection = Direction.Right;
            this.Symbol = GameConstants.SnakeRightSymbol;
        }

        public string Symbol { get; set; }

        public Direction CurrentDirection { get; set; }

        public IReadOnlyCollection<ICoordinate> Body => this.snakeBody.AsReadOnly();

        public ICoordinate Head { get; set; }

        public void InitializeDefaultSnake()
        {
            var x = GameConstants.SnakeDefaultCoordinateX;
            var y = GameConstants.SnakeDefaultCoordinateY;

            for (int i = 0; i <= GameConstants.SnakeDefaultLength; i++)
            {
                this.snakeBody.Add(new Coordinate(x, y));
                x++;
            }

            this.Head = snakeBody.Last();
        }

        public void Move()
        {
            var newCoordinate = this.CalculateNewCoordinate(this.Head);

            this.snakeBody.Add(newCoordinate);
            this.snakeBody.RemoveAt(0);
            this.Head = this.snakeBody.Last();

        }

        public void Eat(IFood food)
        {
            for (int i = 0; i < food.FoodPoints; i++)
            {
                var newHead = this.CalculateNewCoordinate(this.Head);
                this.snakeBody.Add(newHead);
            }

            this.Head = this.snakeBody.Last();
        }

        public ICoordinate CalculateNewCoordinate(ICoordinate currentHeadCoordinate)
        {

            var x = 0;
            var y = 0;

            switch (this.CurrentDirection)
            {
                case Direction.Right:
                    x = currentHeadCoordinate.CoordinateX + 1;
                    y = currentHeadCoordinate.CoordinateY;
                    break;
                case Direction.Left:
                    x = currentHeadCoordinate.CoordinateX - 1;
                    y = currentHeadCoordinate.CoordinateY;
                    break;
                case Direction.Down:
                    x = currentHeadCoordinate.CoordinateX;
                    y = currentHeadCoordinate.CoordinateY + 1;
                    break;
                case Direction.Up:
                    x = currentHeadCoordinate.CoordinateX;
                    y = currentHeadCoordinate.CoordinateY - 1;
                    break;
            }

            return new Coordinate(x, y);
        }
    }
}
