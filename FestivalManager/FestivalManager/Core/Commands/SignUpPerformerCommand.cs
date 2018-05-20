namespace FestivalManager.Core.Commands
{
    using FestivalManager.Core.Controllers.Contracts;

    public class SignUpPerformerCommand : BaseCommand
    {
        public SignUpPerformerCommand(string[] args, IFestivalController festivalController)
            : base(args, festivalController)
        {
        }

        public override string Execute()
        {
            return base.FestivalController.SignUpPerformer(base.Arguments);
        }
    }
}
