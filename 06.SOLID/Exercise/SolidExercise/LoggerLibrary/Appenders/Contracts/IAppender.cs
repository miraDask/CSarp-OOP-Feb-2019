namespace LoggerLibrary.Appenders.Contracts
{
    using Loggers;

    public interface IAppender
    {
        ReportLevel ReportLevel { get; set; }

        int AppendedMessagesCount { get; }

        void Append(string dateTime, ReportLevel reportLevel, string message);
    }
}
