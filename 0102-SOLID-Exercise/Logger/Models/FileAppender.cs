﻿using Logger.Models.Contracts;

namespace Logger.Models.Factories
{
    internal class FileAppender : IAppender
    {
        private ILogFile logFile;

        public FileAppender(ILayout layout, ErrorLevel errorLevel, ILogFile logFile)
        {
            this.Layout = layout;
            this.Level = errorLevel;
            this.logFile = logFile;
            this.MessagesAppended = 0;
        }

        public ILayout Layout { get; }

        public ErrorLevel Level { get; }

        public int MessagesAppended { get; private set; }

        public void Append(IError error)
        {
            string formattedError = this.Layout.FormatError(error);
            this.logFile.WriteToFile(formattedError);
            this.MessagesAppended++;
        }

        public override string ToString()
        {
            var appenderType = this.GetType().Name;
            var layoutType = this.Layout.GetType().Name;
            var reportLevel = this.Level.ToString();

            string result = $"Appender type: {appenderType}, Layout type: {layoutType}, " +
                $"Report level: {reportLevel}, Messages appended: {this.MessagesAppended}, " +
                $"File size: {this.logFile.Size}";

            return result;
        }
    }
}