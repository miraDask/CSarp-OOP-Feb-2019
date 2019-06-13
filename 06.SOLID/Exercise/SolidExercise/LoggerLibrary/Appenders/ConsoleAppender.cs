namespace LoggerLibrary.Appenders
{
    using Layouts.Contracts;
    using Loggers;
    using System;

    public class ConsoleAppender : Appender
    {
        public ConsoleAppender(ILayout layout, ReportLevel reportLevel)
            : base(layout, reportLevel)
        {
        }

        public override void Append(string dateTime, ReportLevel reportLevel, string message)
        {
            if (this.ReportLevel <= reportLevel)
            {
                this.AppendedMessagesCount++;
                Console.WriteLine(string.Format(this.Layout.Format, dateTime, reportLevel, message));
            }
        }
    }
}
