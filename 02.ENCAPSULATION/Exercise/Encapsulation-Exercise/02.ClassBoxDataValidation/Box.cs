namespace _02.ClassBoxDataValidation
{
    using System;

    public class Box
    {
        private double length;
        private double height;
        private double width;

        public Box(double length, double width, double height)
        {
            this.Length = length;
            this.Width = width;
            this.Height = height;
        }

        public double Length
        {
            get => this.length;
            private set
            {
                if (value <= 0)
                {
                    throw new InvalidOperationException("Length cannot be zero or negative.");
                }

                this.length = value;
            }
        }

        public double Height
        {
            get => this.height;
            private set
            {
                if (value <= 0)
                {
                    throw new InvalidOperationException("Height cannot be zero or negative.");
                }

                this.height = value;
            }
        }

        public double Width
        {
            get => this.width;
            private set
            {
                if (value <= 0)
                {
                    throw new InvalidOperationException("Width cannot be zero or negative.");
                }

                this.width = value;
            }
        }

        public string GetSurfaceArea()
        {
            double area = 0;

            area = 2 * (this.Length * this.Width) + 2 * (this.Length * this.Height) + 2 * (this.Width * this.Height);

            return $"Surface Area - {area:F2}";
        }

        public string GetLateralSurfaceArea()
        {
            double area = 0;

            area = 2 * (this.Length * this.Height) + 2 * (this.Width * this.Height);

            return $"Lateral Surface Area - {area:F2}";
        }

        public string GetVolume()
        {
            double volume = 0;

            volume = this.Length * this.Height * this.Width;

            return $"Volume - {volume:F2}";
        }
    }
}
