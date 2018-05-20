namespace FestivalManager
{
    using Core;
    using Core.Controllers;
    using Core.Controllers.Contracts;
    using Core.IO;
    using Core.IO.Contracts;
    using Entities;
    using Entities.Contracts;

    public class StartUp
    {
        public static void Main()
        {
            IReader reader = new LineReader();
            IWriter writer = new LineWriter();

            IStage stage = new Stage();

            IFestivalController festivalController = new FestivalController(stage);
            ISetController setController = new SetController(stage);

            var engine = new Engine(reader, writer, festivalController, setController);

            engine.Run();
        }
    }
}
