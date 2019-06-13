namespace LoggerLibrary.Core
{
    using Appenders.Contracts;
    using Appenders.Factories;
    using Core.Contracts;
    using Layouts.Contracts;
    using Loggers;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class CommandInterpreter : ICommandInterpreter
    {
        private ICollection<IAppender> appenders;
        private IAppenderFactory appenderFactory;
        private ILayoutFactory layoutFactory;

        public CommandInterpreter()
        {
            this.appenders = new List<IAppender>();
            this.appenderFactory = new AppenderFactory();
            this.layoutFactory = new LayoutFactory();
        }

        public void AddAppender(string[] args)
        {
            string appenderType = args[0];
            string layoutType = args[1];

            ILayout layout = this.layoutFactory.CraeteLayout(layoutType);
            ReportLevel reportLevel = ReportLevel.INFO;

            if (args.Length == 3)
            {
                reportLevel= Enum.Parse<ReportLevel>(args[2]);
            }
            
            IAppender appender = appenderFactory.CreateAppender(appenderType, layout, reportLevel);
            this.appenders.Add(appender);
        }

        public void AddReport(string[] args)
        {
            ReportLevel reportLevel = Enum.Parse<ReportLevel>(args[0]);
            string dateTime = args[1];
            string message = args[2];

            foreach (IAppender appender in this.appenders)
            {
                appender.Append(dateTime, reportLevel, message);
            }
        }

        public string WriteInfo()
        {
            StringBuilder result = new StringBuilder();

            result.AppendLine("Logger info");

            foreach (IAppender appender in this.appenders)
            {
                result.AppendLine(appender.ToString());
            }

            return result.ToString().TrimEnd();
        }
    }
}
