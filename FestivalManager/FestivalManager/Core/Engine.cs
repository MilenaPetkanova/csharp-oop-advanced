namespace FestivalManager.Core
{
    using System;
    using System.Linq;
    using System.Reflection;
    using Contracts;
    using Controllers.Contracts;
    using IO.Contracts;

    class Engine : IEngine
	{
	    private IReader reader;
	    private IWriter writer;
        private IFestivalController festivalController;
        private ISetController setController;
        private ICommandFactory commandFactory;

        public Engine(IReader reader, IWriter writer, IFestivalController festivalController, ISetController setController)
        {
            this.reader = reader;
            this.writer = writer;
            this.festivalController = festivalController;
            this.setController = setController;
            this.commandFactory = new CommandFactory();
        }

        public void Run()
        {
            while (true) 
			{
				var input = reader.ReadLine();

				if (input == "END")
                {
					break;
                }

				try
				{
					var result = this.ProcessCommand(input);
					this.writer.WriteLine(result);
				}
				catch (Exception ex) 
				{
					this.writer.WriteLine("ERROR: " + ex.Message);
				}
			}

			var report = this.festivalController.ProduceReport();

			this.writer.WriteLine("Results:");
			this.writer.WriteLine(report);
		}

        public string ProcessCommand(string input)
        {
            var tokens = input.Split(" ".ToCharArray().First());

            var command = this.commandFactory.CreateCommand(tokens, this.festivalController, this.setController);

            var result = command.Execute();

            return result;
        }
    }
}