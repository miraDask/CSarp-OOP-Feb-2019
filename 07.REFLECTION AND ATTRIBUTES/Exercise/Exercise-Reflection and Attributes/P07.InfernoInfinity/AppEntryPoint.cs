namespace P07.InfernoInfinity
{
    using P07.InfernoInfinity.Models.Contracts;
    using P07.InfernoInfinity.Models.Gems;
    using System;
    using Microsoft.Extensions.DependencyInjection;
    using P07.InfernoInfinity.Data;
    using P07.InfernoInfinity.Models;
    using P07.InfernoInfinity.Core.Contracts;
    using P07.InfernoInfinity.Core;

    public class AppEntryPoint
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
            serviceDescriptors.AddTransient<IWeaponFactory, WeaponFactory>();
            serviceDescriptors.AddTransient<IGemFactory, GemFactory>();
            serviceDescriptors.AddSingleton<IWeaponRepository, WeaponRepository>();
            IServiceProvider serviceProvider = serviceDescriptors.BuildServiceProvider();
            return serviceProvider;
        }
    }
}
