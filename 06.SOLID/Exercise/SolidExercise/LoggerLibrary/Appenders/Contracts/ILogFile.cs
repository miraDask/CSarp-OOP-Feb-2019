namespace LoggerLibrary.Appenders.Contracts
{
    public interface ILogFile
    {
        int Size { get; }

        string Write();
    }
}
