namespace SimpleSnake.GameObjects
{
    using SimpleSnake.GameObjects.Contracts;
    using System.Collections.Generic;
    //TODO - write more levels
    public abstract class Level : ILevel
    {
        protected Level(int number, int startingPoints)
        {
            this.Number = number;
            this.StartingPoints = startingPoints;
            this.Obstacles = GetObstacles();
        }

        public int Number { get; private set; }

        public int StartingPoints { get; private set; }

        public IReadOnlyCollection<ICoordinate> Obstacles { get; private set; }

        protected abstract List<ICoordinate> GetObstacles();
    }
}
