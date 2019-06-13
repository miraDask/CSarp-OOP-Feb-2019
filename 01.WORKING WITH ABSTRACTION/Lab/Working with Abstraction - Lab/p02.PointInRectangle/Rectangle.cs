namespace p02.PointInRectangle
{
    public class Rectangle
    {
        public Rectangle(int topLeftX ,int topLeftY, int bottomRightX, int bottomRightY)
        {
            TopLeftPoint = new Point(topLeftX, topLeftY);
            BottomRightPoint = new Point(bottomRightX, bottomRightY);
        }   
        
        public Point TopLeftPoint  { get; set; }

        public Point BottomRightPoint { get; set; }

        public bool Contains(Point point)
        {
            bool isInHorizontal = TopLeftPoint.X <= point.X && BottomRightPoint.X >= point.X;
            bool isInVertical = TopLeftPoint.Y <= point.Y && BottomRightPoint.Y >= point.Y;
            bool isInRectangle = isInHorizontal && isInVertical;

            return isInRectangle;
        }
    }
}
