namespace FestivalManager.Core.Commands
{
    using FestivalManager.Core.Controllers.Contracts;

    public class RepairInstrumentsCommand : BaseCommand
    {
        private IFestivalController festivalController;

        public RepairInstrumentsCommand(string[] args, IFestivalController festivalController)
            : base(args)
        {
            this.festivalController = festivalController;
        }

        public override string Execute()
        {
            return this.festivalController.RepairInstruments(base.Arguments);
        }
    }
}
