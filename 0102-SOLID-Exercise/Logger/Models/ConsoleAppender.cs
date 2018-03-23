using Logger.Models.Contracts;
using System;

namespace Logger.Models
{
    public class ConsoleAppender : IAppender
    {
        public ConsoleAppender(ILayout layout, ErrorLevel level)
        {
            this.Layout = layout;
            this.Level = level;
        }

        public ILayout Layout { get; }

        public ErrorLevel Level { get; }

        public int MessagesAppended { get; private set; }

        public void Append(IError error)
        {
            string formattedError = this.Layout.FormatError(error);
            Console.WriteLine(formattedError);
            this.MessagesAppended++;
        }

        public override string ToString()
        {
            var appenderType = this.GetType().Name;
            var layoutType = this.Layout.GetType().Name;
            var reportLevel = this.Level.ToString();

            string result = $"Appender type: {appenderType}, Layout type: {layoutType}, " +
                $"Report level: {reportLevel}, Messages appended: {this.MessagesAppended}";

            return result;
        }
    }
}
