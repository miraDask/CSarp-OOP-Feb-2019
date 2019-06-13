namespace _03BarracksFactory.Core.Commands
{
    using _03BarracksFactory.Contracts;
    using System;
    using System.Linq;
    using System.Reflection;

    public class CommandInterpreter : ICommandInterpreter
    {
        
        private IServiceProvider serviceProvider;

        public CommandInterpreter(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        public IExecutable InterpretCommand(string[] data, string commandName)
        {
            var type = Assembly
               .GetExecutingAssembly()
               .GetTypes()
               .FirstOrDefault(x => x.Name.ToLower() == commandName + "command");

            var constructorParams = type.
                GetConstructors()
                .FirstOrDefault()
                .GetParameters()
                .Select(x => x.ParameterType)
                .Skip(1)
                .ToArray();

            var services = constructorParams
                .Select(this.serviceProvider.GetService);

            var parameters = new object[] { data }.Concat(services).ToArray();

            var instance = (IExecutable)Activator.CreateInstance(type, parameters);
            return instance;
        }
    }
}
