namespace LoggerLibrary.Loggers.Contracts
{
    using Appenders.Contracts;

    public class Logger : ILogger
    {
        private IAppender appender;

        public Logger(IAppender appender)
        {
            this.appender = appender;
        }

        public void Critical(string dateTime, string message)
        {
            this.appender.Append(dateTime, ReportLevel.CRITICAL, message);
        }

        public void Error(string dateTime, string message)
        {
            this.appender.Append(dateTime, ReportLevel.ERROR, message);
        }

        public void Fatal(string dateTime, string message)
        {
            this.appender.Append(dateTime, ReportLevel.FATAL, message);
        }

        public void Info(string dateTime, string message)
        {
            this.appender.Append(dateTime, ReportLevel.INFO, message);
        }

        public void Warning(string dateTime, string message)
        {
            this.appender.Append(dateTime, ReportLevel.WARNING, message);
        }
    }
}
