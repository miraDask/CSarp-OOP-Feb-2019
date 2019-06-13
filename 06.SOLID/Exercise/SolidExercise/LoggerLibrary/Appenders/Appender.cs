namespace LoggerLibrary.Appenders
{
    using Appenders.Contracts;
    using Layouts.Contracts;
    using LoggerLibrary.Loggers;

    public abstract class Appender : IAppender
    {
        protected Appender(ILayout layout, ReportLevel reportLevel)
        {
            this.Layout = layout;
            this.ReportLevel = reportLevel;
        }

        protected ILayout Layout { get; }

        public ReportLevel ReportLevel { get; set; }

        public int AppendedMessagesCount { get; protected set; } = 0;

        public abstract void Append(string dateTime, ReportLevel reportLevel, string message);

        public override string ToString()
        {
            return $"Appender type: {this.GetType().Name}," +
                $" Layout type: {this.Layout.GetType().Name}," +
                $" Report level: {this.ReportLevel}," +
                $" Messages appended: {this.AppendedMessagesCount}";
        }
    }
}
