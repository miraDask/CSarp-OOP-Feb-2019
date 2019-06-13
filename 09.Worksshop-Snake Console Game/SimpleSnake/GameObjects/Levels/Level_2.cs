namespace SimpleSnake.GameObjects.Levels
{
    using SimpleSnake.Constants;
    using SimpleSnake.GameObjects.Contracts;
    using System.Collections.Generic;

    public class Level_2 : Level
    {
        public Level_2()
            : base(2, GameConstants.Level_2StartingPoints)
        {
        }

        protected override List<ICoordinate> GetObstacles()
        {
            var obstacles = new List<ICoordinate>();
            this.AddAllHorizontalObstaclesCoordinates(obstacles);
            this.AddAllVerticalObstaclesCoordinates(obstacles);

            return obstacles;
        }

        private void AddAllVerticalObstaclesCoordinates(List<ICoordinate> obstacles)
        {
            for (int y = 10; y < GameConstants.BoardDefaultHeight - 8; y += 2)
            {
                obstacles.Add(new Coordinate(10, y));
                obstacles.Add(new Coordinate(GameConstants.BoardDefaultWidth - 10, y));
            }
        }

        private void AddAllHorizontalObstaclesCoordinates(List<ICoordinate> obstacles)
        {
            for (int x = 20; x < GameConstants.BoardDefaultWidth - 20; x += 4)
            {
                obstacles.Add(new Coordinate(x, 5));
                obstacles.Add(new Coordinate(x, GameConstants.BoardDefaultHeight - 5));
            }
        }
    }
}
