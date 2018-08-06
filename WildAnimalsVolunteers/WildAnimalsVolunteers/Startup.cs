namespace WildAnimalsVolunteers
{
    using System;
    using Microsoft.Extensions.DependencyInjection;
    using WildAnimalsVolunteers.Core;
    using WildAnimalsVolunteers.Interfaces;

    public class Startup
    {
        public static void Main()
        {
            IServiceProvider serviceProvider = ConfigureServices();

            //IInputReader consoleReader = new ConsoleLineReader();
            //IOutputWriter consoleWriter = new ConsoleLineWriter();
            IVolunteersController volunteersController = new VolunteersController(); ;

            //var engine = new Engine(consoleReader, consoleWriter, volunteersController);
            //engine.Run();
        }

        private static IServiceProvider ConfigureServices()
        {
            IServiceCollection services = new ServiceCollection();

            services.AddSingleton<ICategoryFactory, CategoryFactory>();
            services.AddSingleton<IVolunteersFactory, CategoryFactory>();
            services.AddSingleton<ICategoryFactory, CategoryFactory>();
            services.AddSingleton<ICategoryFactory, CategoryFactory>();
        }
    }
}