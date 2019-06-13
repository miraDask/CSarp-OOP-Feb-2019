namespace LoggerLibrary.Core.Contracts
{
    public interface ICommandInterpreter
    {
        void AddAppender(string[] args);

        void AddReport(string[] args);

        string WriteInfo();
    }
}
