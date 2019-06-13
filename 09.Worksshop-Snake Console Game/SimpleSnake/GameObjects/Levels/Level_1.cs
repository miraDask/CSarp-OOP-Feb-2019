namespace SimpleSnake.GameObjects.Levels
{
    using SimpleSnake.Constants;
    using SimpleSnake.GameObjects.Contracts;
    using System.Collections.Generic;

    public class Level_1 : Level
    {
        public Level_1() 
            : base(1, GameConstants.Level_1StartingPoints)
        {
        }

        protected override List<ICoordinate> GetObstacles()
        {
            return new List<ICoordinate>();
        }
    }
}
