namespace Logger
{
    using Logger.Models;
    using Logger.Models.Contracts;
    using Logger.Models.Factories;
    using System;
    using System.Collections.Generic;

    class Startup
    {
        static void Main(string[] args)
        {
            ILogger logger = InitializeILogger();
            ErrorFactory errorFactory = new ErrorFactory();

            var engine = new Engine(logger, errorFactory);
            engine.Run();
        }

        static ILogger InitializeILogger()
        {
            ICollection<IAppender> appenders = new List<IAppender>();
            LayoutFactory layoutFactory = new LayoutFactory();
            AppenderFactory appenderFactory = new AppenderFactory(layoutFactory);

            int appenderCount = int.Parse(Console.ReadLine());
            for (int i = 0; i < appenderCount; i++)
            {
                var input = Console.ReadLine().Split();
                var appenderType = input[0];
                var layoutType = input[1];
                var errorLevel = "INFO";

                if (input.Length == 3)
                {
                    errorLevel = input[2];
                }

                IAppender appender = appenderFactory.CreateAppender(appenderType, errorLevel, layoutType);
                appenders.Add(appender);
            }

            ILogger logger = new Logger(appenders);

            return logger;
        }
    }
}
