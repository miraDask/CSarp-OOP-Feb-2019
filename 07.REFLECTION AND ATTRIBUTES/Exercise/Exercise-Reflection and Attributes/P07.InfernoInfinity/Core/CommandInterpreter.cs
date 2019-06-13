namespace P07.InfernoInfinity.Core
{
    using P07.InfernoInfinity.Core.Contracts;
    using System;
    using System.Linq;
    using System.Reflection;

    public class CommandInterpreter : ICommandInterpreter
    {
        private const string Suffix = "Command";
        private IServiceProvider serviceProvider;

        public CommandInterpreter(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        public IExecutable GetCommand(string[] data)
        {
            string commandName = data[0] + Suffix; ;

            var commandType = Assembly
                .GetExecutingAssembly()
                .GetTypes()
                .FirstOrDefault(x => x.Name == commandName);

            var constuctorParams = commandType
                .GetConstructors()
                .FirstOrDefault()
                .GetParameters()
                .Select(x => x.ParameterType)
                .Skip(1)
                .ToArray();

            var services = constuctorParams
                .Select(this.serviceProvider.GetService)
                .ToArray();

            var parameters = new object[] { data }.Concat(services).ToArray();

            var instance = (IExecutable)Activator.CreateInstance(commandType, parameters);
            return instance;
        }
    }
}
