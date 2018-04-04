namespace _03BarracksFactory.Core.Commands
{
    using Contracts;

    public abstract class Command : IExecutable
    {
        private string[] data;

        public Command(string[] data)
        {
            this.Data = data;
        }

        public string[] Data
        {
            get { return data; }
            set { data = value; }
        }

        public abstract string Execute();
    }
}