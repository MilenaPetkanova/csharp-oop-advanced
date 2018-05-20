namespace FestivalManager.Core.Commands
{
    using FestivalManager.Core.Controllers.Contracts;

    public class AddPerformerToSetCommand : BaseCommand
    {
        public AddPerformerToSetCommand(string[] args, IFestivalController festivalController) 
            : base(args, festivalController)
        {
        }

        public override string Execute()
        {
            return base.FestivalController.AddPerformerToSet(base.Arguments);
        }
    }
}
