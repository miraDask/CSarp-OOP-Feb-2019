namespace SimpleSnake.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;

    using SimpleSnake.Constants;
    using SimpleSnake.Enums;
    using SimpleSnake.GameObjects;
    using SimpleSnake.GameObjects.Contracts;
    using SimpleSnake.GameObjects.Foods;
    using SimpleSnake.GameObjects.Levels;

    public class Engine
    {
        private IHero snake;
        private IFood currentFood;
        private DrawManager drawManager;
        private FactoryFood factoryFood;
        private List<ICoordinate> boarderCoordinates;
        private int gameScore;
        private int lastFoodTime;
        private ILevel level;
        private LevelFactory levelFactory;

        public Engine(IHero snake, DrawManager drawManager, ILevel level)
        {
            this.snake = snake;
            this.drawManager = drawManager;
            this.factoryFood = new FactoryFood();
            InitializeFood();
            InitializeBoarder();
            this.gameScore = 0;
            this.level = level;
            this.levelFactory = new LevelFactory();
        }


        public void Run()
        {
            this.drawManager.Draw(GameConstants.BoarderDafaultSymbol, this.boarderCoordinates);

            while (true)
            {
                PlayerInfo();

                DrawObstacles();

                if (Console.KeyAvailable)
                {
                    this.SetNewDirection(Console.ReadKey());
                }

                this.drawManager.Draw(currentFood.FoodSymbol, new List<ICoordinate>() { this.currentFood.FoodCoordinate });

                this.drawManager.Draw(this.snake.Symbol, this.snake.Body);

                this.snake.Move();

                if (HasBoarderCollision()
                    || HasSelfCollision()
                    || HasObstacleCollision()) 
                {
                    AskPlayerForRestart();
                }

                this.drawManager.UndoDrawn();

                if (HasEatCollision())
                {
                    this.snake.Eat(currentFood);
                    this.gameScore += currentFood.FoodPoints;
                    this.InitializeFood();
                    this.lastFoodTime = Environment.TickCount;
                }

                if (Environment.TickCount - this.lastFoodTime >= GameConstants.FoodDissapeareTime )
                {
                    Console.SetCursorPosition(this.currentFood.FoodCoordinate.CoordinateX, this.currentFood.FoodCoordinate.CoordinateY);
                    Console.Write(" ");
                    InitializeFood();
                }

                SetSnakeSpeed();
            }
        }

        private void DrawObstacles()
        {
            if (this.gameScore - this.level.StartingPoints >= GameConstants.LevelsOffset)
            {
                this.level = this.levelFactory.GetLevel(this.level.Number + 1);
                this.drawManager.Draw(GameConstants.BoarderDafaultSymbol, this.level.Obstacles);
            }
        }

        private void SetSnakeSpeed()
        {
            var currentSpeed = 0;
            if (snake.CurrentDirection == Direction.Left || snake.CurrentDirection == Direction.Right)
            {
                currentSpeed = GameConstants.SuspentionTimeLeftRight;
            }
            else
            {
                currentSpeed = GameConstants.SuspentionTimeUpDown;
            }

            Thread.Sleep(currentSpeed - this.gameScore);
        }

        private void PlayerInfo()
        {
            Console.SetCursorPosition(GameConstants.BoardDefaultWidth + GameConstants.PlayerScoreOffsetX, GameConstants.PlayerScoreOffsetY);
            Console.WriteLine(string.Format(GameConstants.PlayerScoreMessage, this.gameScore));
            Console.SetCursorPosition(GameConstants.BoardDefaultWidth + GameConstants.PlayerScoreOffsetX, GameConstants.PlayerScoreOffsetY + 1);
            Console.Write(string.Format(GameConstants.PlayerLevelMessage, this.level.Number));
        }

        private void AskPlayerForRestart()
        {
            var x = GameConstants.RestartMessageCoordinateX;
            var y = GameConstants.RestartMessageCoordinateY;
            Console.SetCursorPosition(x, y);
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.Write(GameConstants.RestartMessage);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(GameConstants.RestartAdditionalMessage);
            var input = Console.ReadKey();

            if (input.Key == ConsoleKey.Y)
            {
                Console.Clear();
                StartUp.Main();
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Game over!");
                Environment.Exit(0);
            }
        }

        private void SetNewDirection(ConsoleKeyInfo readKey)
        {
            switch (readKey.Key)
            {
                case ConsoleKey.LeftArrow:
                    if (this.snake.CurrentDirection != Direction.Right)
                    {
                        this.snake.CurrentDirection = Direction.Left;
                        this.snake.Symbol = GameConstants.SnakeLeftSymbol;
                    }
                    break;
                case ConsoleKey.RightArrow:
                    if (this.snake.CurrentDirection != Direction.Left)
                    {
                        this.snake.CurrentDirection = Direction.Right;
                        this.snake.Symbol = GameConstants.SnakeRightSymbol;

                    }
                    break;
                case ConsoleKey.UpArrow:
                    if (this.snake.CurrentDirection != Direction.Down)
                    {
                        this.snake.CurrentDirection = Direction.Up;
                        this.snake.Symbol = GameConstants.SnakeUpSymbol;

                    }
                    break;
                case ConsoleKey.DownArrow:
                    if (this.snake.CurrentDirection != Direction.Up)
                    {
                        this.snake.CurrentDirection = Direction.Down;
                        this.snake.Symbol = GameConstants.SnakeDownSymbol;

                    }
                    break;
            }

        }

        private void InitializeFood()
        {
            this.currentFood = this.factoryFood
                .GenerateRandomFood(GameConstants.BoardDefaultWidth, GameConstants.BoardDefaultHeight);

            this.lastFoodTime = Environment.TickCount;
        }

        private bool HasEatCollision()
        {
            var snakeHeadCoordinateX = this.snake.Head.CoordinateX;
            var snakeHeadCoordinateY = this.snake.Head.CoordinateY;
            var foodCoordinateX = this.currentFood.FoodCoordinate.CoordinateX;
            var foodCoordinateY = this.currentFood.FoodCoordinate.CoordinateY;

            return snakeHeadCoordinateX == foodCoordinateX
                && snakeHeadCoordinateY == foodCoordinateY;
        }

        private bool HasBoarderCollision()
        {
            var snakeHeadCoordinateX = this.snake.Head.CoordinateX;
            var snakeHeadCoordinateY = this.snake.Head.CoordinateY;

            if (this.boarderCoordinates.Any(x => x.CoordinateX == snakeHeadCoordinateX
                  && x.CoordinateY == snakeHeadCoordinateY))
            {
                return true;
            }

            return false;
        }

        private bool HasObstacleCollision()
        {
            var snakeHeadCoordinateX = this.snake.Head.CoordinateX;
            var snakeHeadCoordinateY = this.snake.Head.CoordinateY;

            if (this.level.Obstacles.Any(x => x.CoordinateX == snakeHeadCoordinateX
                  && x.CoordinateY == snakeHeadCoordinateY))
            {
                return true;
            }

            return false;
        }

        private bool HasSelfCollision()
        {
            var snakeHeadCoordinateX = this.snake.Head.CoordinateX;
            var snakeHeadCoordinateY = this.snake.Head.CoordinateY;
            var body = this.snake.Body.ToList();

            for (int i = 0; i < this.snake.Body.Count - 1; i++)
            {
                if (body[i].CoordinateX == snakeHeadCoordinateX && body[i].CoordinateY == snakeHeadCoordinateY)
                {
                    return true;
                }
            }

            return false;
        }

        private void InitializeBoarder()
        {
            this.boarderCoordinates = new List<ICoordinate>();
            AddAllHorizontalBoarderCoordinates();
            AddAllVerticalBoarderCoordinates();
        }

        private void AddAllVerticalBoarderCoordinates()
        {
            for (int y = 2; y < GameConstants.BoardDefaultHeight; y++)
            {
                this.boarderCoordinates.Add(new Coordinate(2, y));
                this.boarderCoordinates.Add(new Coordinate(GameConstants.BoardDefaultWidth, y));
            }
        }

        private void AddAllHorizontalBoarderCoordinates()
        {
            for (int x = 2; x < GameConstants.BoardDefaultWidth; x++)
            {
                this.boarderCoordinates.Add(new Coordinate(x, 2));
                this.boarderCoordinates.Add(new Coordinate(x, GameConstants.BoardDefaultHeight));
            }
        }
    }
}
