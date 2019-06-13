namespace Operations
{
    public class MathOperations
    {
        public int Add(int first, int second)
        {
            return first + second;
        }

        public double Add(double first, double second, double last)
        {
            return first + second + last;
        }

        public decimal Add(decimal first, decimal second, decimal last)
        {
            return first + second + last;
        }
    }
}
