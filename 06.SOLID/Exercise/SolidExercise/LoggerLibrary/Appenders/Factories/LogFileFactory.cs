namespace LoggerLibrary.Appenders.Factories
{
    using Appenders.Contracts;

    public class LogFileFactory : ILogFileFactory
    {
        public ILogFile CreateLogFile(string filePath)
        {
            return new LogFile(filePath);
        }
    }
}
