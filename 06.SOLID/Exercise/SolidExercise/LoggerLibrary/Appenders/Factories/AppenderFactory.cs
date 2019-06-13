namespace LoggerLibrary.Appenders.Factories
{
    using Appenders.Contracts;
    using Layouts.Contracts;
    using Loggers;
    using System;

    public class AppenderFactory : IAppenderFactory
    {
        private const string FilePathFormat = @"..\..\..\log{0}.txt";
        private int fileCount = 1;
        private ILogFileFactory logFileFactory = new LogFileFactory();

        public IAppender CreateAppender(string appenderType, ILayout layout, ReportLevel reportLevel)
        {
            string appenderTypeToLowerCase = appenderType.ToLower();

            switch (appenderTypeToLowerCase)
            {
                case "consoleappender":
                    return new ConsoleAppender(layout, reportLevel);

                case "fileappender":
                    string filePath = string.Format(FilePathFormat, fileCount++);
                    ILogFile logFile = logFileFactory.CreateLogFile(filePath);
                    return new FileAppender(layout, reportLevel, logFile, filePath);
                    
                default:
                    throw new ArgumentException("Ivalid appender type!");
            }
        }
    }
}
