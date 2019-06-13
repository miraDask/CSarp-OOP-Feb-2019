using SimpleSnake.Constants;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleSnake.GameObjects.Foods
{
    public class FoodHash : Food
    {
        public FoodHash(Coordinate foodCoordinate)
            : base(GameConstants.FoodHashSymbol, GameConstants.FoodHashPoints, foodCoordinate)
        {
        }
    }
}
