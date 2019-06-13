namespace _03BarracksFactory.Core.Commands
{
    using _03BarracksFactory.Contracts;

    public class RetireCommand : Command
    {
        private IRepository repository;

        public RetireCommand(string[] data, IRepository repository) 
            : base(data)
        {
            this.Repository = repository;
        }

        public IRepository Repository { get => this.repository; private set => this.repository = value; }

        public override string Execute()
        {
            string unitType = this.Data[1];

            this.Repository.RemoveUnit(unitType);

            return $"{unitType} retired!";
        }
    }
}
