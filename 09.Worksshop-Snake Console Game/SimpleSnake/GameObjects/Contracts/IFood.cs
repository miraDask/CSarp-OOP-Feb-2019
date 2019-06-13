using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleSnake.GameObjects.Contracts
{
    public interface IFood
    {
        string FoodSymbol { get; set; }

        int FoodPoints { get; }

        Coordinate FoodCoordinate { get; }
    }
}
