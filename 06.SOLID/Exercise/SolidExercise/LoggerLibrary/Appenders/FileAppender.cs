namespace LoggerLibrary.Appenders
{
    using Appenders.Contracts;
    using Layouts.Contracts;
    using Loggers;
    using System;
    using System.IO;

    public class FileAppender : Appender
    {
        private string filePath; 
        private ILogFile logFile;

        public FileAppender(ILayout layout, ReportLevel reportLevel, ILogFile logFile, string filePath)
            : base(layout, reportLevel)
        {
            this.logFile = logFile;
            this.filePath = filePath;
        }

        public override void Append(string dateTime, ReportLevel reportLevel, string message)
        {
            if (this.ReportLevel <= reportLevel)
            {
                string formatedText = string.Format(this.Layout.Format, dateTime, reportLevel, message);
                this.AppendedMessagesCount++;
                File.AppendAllText(this.filePath, formatedText + Environment.NewLine);
            }
        }

        public override string ToString()
        {
            return base.ToString() + $", {this.logFile.Write()}";
        }
    }
}
