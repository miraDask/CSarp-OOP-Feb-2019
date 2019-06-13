namespace _03BarracksFactory.Core.Commands
{
    using _03BarracksFactory.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Text;

    public class CommandInterpreter : ICommandInterpreter
    {
        private IRepository repository;
        private IUnitFactory unitFactory;

        public CommandInterpreter(IRepository repository, IUnitFactory unitFactory)
        {
            this.repository = repository;
            this.unitFactory = unitFactory;
        }

        public IExecutable InterpretCommand(string[] data, string commandName)
        {
            var type = Assembly
               .GetExecutingAssembly()
               .GetTypes()
               .FirstOrDefault(x => x.Name.ToLower() == commandName + "command");

            var instance = (IExecutable)Activator.CreateInstance(type, new object[] { data, repository, unitFactory });
            return instance;
        }
    }
}
