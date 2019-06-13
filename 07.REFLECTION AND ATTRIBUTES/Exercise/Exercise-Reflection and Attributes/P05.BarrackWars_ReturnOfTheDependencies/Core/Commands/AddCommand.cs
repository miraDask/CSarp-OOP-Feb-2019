namespace _03BarracksFactory.Core.Commands
{
    using _03BarracksFactory.Contracts;

    public class AddCommand : Command
    {
        
        private IRepository repository;
        private IUnitFactory unitFactory;

        public AddCommand(string[] data, IRepository repository, IUnitFactory unitFactory)
            : base(data)
        {
            this.repository = repository;
            this.unitFactory = unitFactory;
        }

        public IRepository Repository { get =>this.repository; private set => this.repository = value; }

        public IUnitFactory UnitFactory { get => this.unitFactory; private set => this.unitFactory = value; }

        public override string Execute()
        {
            string unitType = this.Data[1];
            IUnit unitToAdd = this.UnitFactory.CreateUnit(unitType);
            this.Repository.AddUnit(unitToAdd);
            string output = unitType + " added!";
            return output;
        }
    }
}
