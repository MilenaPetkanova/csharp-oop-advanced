namespace FestivalManager.Core.Commands
{
    using FestivalManager.Core.Controllers.Contracts;

    public class RegisterSetCommand : BaseCommand
    {
        public RegisterSetCommand(string[] args, IFestivalController festivalController) 
            : base(args, festivalController)
        {
        }

        public override string Execute()
        {
            return base.FestivalController.RegisterSet(base.Arguments);
        }
    }
}
