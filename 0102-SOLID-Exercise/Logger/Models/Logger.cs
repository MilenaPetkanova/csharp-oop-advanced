using Logger.Models.Contracts;
using System.Collections.Generic;

namespace Logger.Models
{
    public class Logger : ILogger
    {
        IEnumerable<IAppender> appernders;

        public Logger(IEnumerable<IAppender> appernders)
        {
            this.appernders = appernders;
        }

        public IReadOnlyCollection<IAppender> Appenders => (IReadOnlyCollection<IAppender>)this.appernders;

        public void Log(IError error)
        {
            foreach (IAppender appender in this.appernders)
            {
                if (appender.Level <= error.Level)
                {
                    appender.Append(error);
                }
            }
        }
    }
}
