namespace MuOnline.Core
{
    using System;
    using System.Linq;
    using System.Reflection;

    using Core.Commands.Contracts;
    using Core.Contracts;
    using Utilities;

    public class CommandInterpreter : ICommandInterpreter
    {
        private const string Suffix = "command";
        private readonly IServiceProvider serviceProvider;

        public CommandInterpreter(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        public string Read(string[] args)
        {
            Validator.InputLengthValidate(args);

            var commandName = args[0].ToLower() + Suffix;

            var commandType = Assembly
                .GetExecutingAssembly()
                .GetTypes()
                .FirstOrDefault(x => x.Name.ToLower() == commandName);

            Validator.ObjecIsNotNullValidation(commandType);

            var constructor = commandType
                .GetConstructors()
                .FirstOrDefault();

            var constructorParams = constructor
                .GetParameters()
                .Select(x => x.ParameterType)
                .ToArray();

            var services = constructorParams
                .Select(this.serviceProvider.GetService)
                .ToArray();

            var commandInstance =(ICommand)Activator
                .CreateInstance(commandType, services);

            args = args.Skip(1).ToArray();

            return commandInstance.Execute(args);
        }
    }
}
