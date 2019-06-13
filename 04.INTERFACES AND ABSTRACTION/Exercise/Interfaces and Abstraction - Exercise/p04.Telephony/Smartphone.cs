namespace p04.Telephony
{
    using System.Linq;

    public class Smartphone : ICallable, IBrowsable
    {
        public string Brows(string url)
        {
            if (url.Any(x => char.IsDigit(x)))
            {
                return "Invalid URL!";
            }

            return $"Browsing: {url}!";
        }

        public string Call(string number)
        {
            if (number.Any(x => char.IsLetter(x)))
            {
                return "Invalid number!";
            }

            return $"Calling... {number}";
        }
    }
}
