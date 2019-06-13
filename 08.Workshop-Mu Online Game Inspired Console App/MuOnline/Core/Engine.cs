namespace MuOnline.Core
{
    using System;
    using Microsoft.Extensions.DependencyInjection;

    using Contracts;

    public class Engine : IEngine
    {
        private readonly IServiceProvider serviceProvider;

        public Engine(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        public void Run()
        {
            while (true)
            {
                try
                {
                    var reader = serviceProvider.GetService<IReader>();

                    var commandArgs = reader.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                    var commandInterpreter = serviceProvider.GetService<ICommandInterpreter>();
                    var result = commandInterpreter.Read(commandArgs);

                    var writer = serviceProvider.GetService<IWriter>();
                    writer.WriteLine(result);
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                }
                catch (InvalidOperationException ioe)
                {
                    Console.WriteLine(ioe.Message);
                }
            }
        }
    }
}
