namespace FestivalManager.Core.Commands
{
    using FestivalManager.Core.Controllers.Contracts;

    public class AddSongToSetCommand : BaseCommand
    {
        public AddSongToSetCommand(string[] args, IFestivalController festivalController)
            : base(args, festivalController)
        {
        }

        public override string Execute()
        {
            return base.FestivalController.AddSongToSet(base.Arguments);
        }
    }
}
