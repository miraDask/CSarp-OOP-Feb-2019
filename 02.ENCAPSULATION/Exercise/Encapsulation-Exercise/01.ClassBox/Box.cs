namespace _01.ClassBox
{
    public class Box
    {
        private double length;
        private double height;
        private double width;

        public Box(double length, double width, double height)
        {
            this.length = length;
            this.width = width;
            this.height = height;
        }

        public string GetSurfaceArea()
        {
            double area = 0;

            area =  2 * (this.length * this.width) + 2 * (this.length * this.height) + 2 * (this.width * this.height);

            return $"Surface Area - {area:F2}";
        }

        public string GetLateralSurfaceArea()
        {
            double area = 0;

            area =  2 * (this.length * this.height) + 2 * (this.width * this.height);

            return $"Lateral Surface Area - {area:F2}";
        }

        public string GetVolume()
        {
            double volume = 0;

            volume = this.length * this.height * this.width;

            return $"Volume - {volume:F2}";
        }
    }
}
