namespace SimpleSnake.GameObjects.Foods
{
    using SimpleSnake.Constants;

    public class FoodDollar : Food
    {
        public FoodDollar(Coordinate foodCoordinate)
            : base(GameConstants.FoodDollarSymbol, GameConstants.FoodDollarPoints, foodCoordinate)
        {
        }
    }
}
