namespace FestivalManager.Core.Commands
{
    using FestivalManager.Core.Controllers.Contracts;

    public class RepairInstrumentsCommand : BaseCommand
    {
        public RepairInstrumentsCommand(string[] args, IFestivalController festivalController)
            : base(args, festivalController)
        {
        }

        public override string Execute()
        {
            return base.FestivalController.RepairInstruments(base.Arguments);
        }
    }
}
