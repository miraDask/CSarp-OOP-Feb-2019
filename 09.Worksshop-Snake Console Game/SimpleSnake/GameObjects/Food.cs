using SimpleSnake.GameObjects.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleSnake.GameObjects
{
    public abstract class Food : IFood
    {
        protected Food(string foodSymbol, int foodPoints, Coordinate foodCoordinate)
        {
            this.FoodSymbol = foodSymbol;
            this.FoodPoints = foodPoints;
            this.FoodCoordinate = foodCoordinate;
        }

        public string FoodSymbol { get; set; }

        public int FoodPoints { get; private set; }

        public Coordinate FoodCoordinate { get; private set; }
    }
}
