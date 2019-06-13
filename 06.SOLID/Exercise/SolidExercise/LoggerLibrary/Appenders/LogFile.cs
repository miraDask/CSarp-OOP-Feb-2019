namespace LoggerLibrary.Appenders
{
    using LoggerLibrary.Appenders.Contracts;
    using System.IO;
    using System.Linq;

    public class LogFile : ILogFile
    {
        private string filePath;

        public LogFile(string filePath)
        {
            this.filePath = filePath;
        }

        public int Size => this.CalculateSize();

        public string Write()
        {
            return $"File size: {this.Size}";
        }

        private int CalculateSize()
        {
            string[] text = File.ReadAllLines(this.filePath);
            int size = 0;

            foreach (var line in text)
            {
                size += line.Where(x => char.IsLetter(x)).Sum(x => x);
            }

            return size;
        }
    }
}
