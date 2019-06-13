namespace SimpleSnake.GameObjects.Foods
{
    using SimpleSnake.Constants;

    public class FoodAsterisk : Food
    {
        public FoodAsterisk(Coordinate foodCoordinate)
            : base(GameConstants.FoodAsteriksSymbol, GameConstants.FoodAsteriksPoints, foodCoordinate)
        {
        }
    }
}
