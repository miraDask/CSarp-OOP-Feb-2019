﻿namespace Shapes
{
    public class Rectangle : Shape
    {
        private readonly double height;
        private readonly double width;

        public Rectangle(double height, double width)
        {
            this.height = height;
            this.width = width;
        }

        public override double CalculateArea()
        {
            return this.height * this.width;
        }

        public override double CalculatePerimeter()
        {
            return (this.height * 2) + (this.width * 2);
        }

        public override string Draw()
        {
            return base.Draw() + $"{this.GetType().Name}";
        }
    }
}
