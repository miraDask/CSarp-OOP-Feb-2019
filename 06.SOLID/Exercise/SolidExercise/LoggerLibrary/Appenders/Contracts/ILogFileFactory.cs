namespace LoggerLibrary.Appenders.Contracts
{
    public interface ILogFileFactory
    {
        ILogFile CreateLogFile(string filePath);
    }
}
