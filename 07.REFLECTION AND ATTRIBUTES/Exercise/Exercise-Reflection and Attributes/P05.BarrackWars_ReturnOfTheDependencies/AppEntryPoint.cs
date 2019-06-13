namespace _03BarracksFactory
{
    using Contracts;
    using Core;
    using Core.Factories;
    using Data;
    using _03BarracksFactory.Core.Commands;
    using Microsoft.Extensions.DependencyInjection;
    using System;

    class AppEntryPoint
    {
        static void Main(string[] args)
        {
            IServiceProvider serviceProvider = GetServiceProvider();
            ICommandInterpreter commandInterpreter = new CommandInterpreter(serviceProvider);
            IRunnable engine = new Engine(commandInterpreter);
            engine.Run();
        }

        private static IServiceProvider GetServiceProvider()
        {
            IServiceCollection serviceDescriptors = new ServiceCollection();
            serviceDescriptors.AddTransient<IUnitFactory, UnitFactory>();
            serviceDescriptors.AddSingleton<IRepository, UnitRepository>();
            IServiceProvider serviceProvider = serviceDescriptors.BuildServiceProvider();
            return serviceProvider;
        }
    }
}
