namespace LoggerLibrary.Appenders.Contracts
{
    using Layouts.Contracts;
    using Loggers;

    public interface IAppenderFactory
    {
        IAppender CreateAppender(string appenderType, ILayout layout, ReportLevel reportLevel);
    }
}
