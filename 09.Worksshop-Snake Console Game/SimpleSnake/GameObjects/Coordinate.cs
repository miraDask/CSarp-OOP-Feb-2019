namespace SimpleSnake.GameObjects
{
    using SimpleSnake.GameObjects.Contracts;
    using System.Collections;

    public class Coordinate : ICoordinate
    {
        public Coordinate(int coordinateX, int coordinateY)
        {
            this.CoordinateX = coordinateX;
            this.CoordinateY = coordinateY;
        }

        public int CoordinateX { get; set; }

        public int CoordinateY { get; set; }
    }
}
