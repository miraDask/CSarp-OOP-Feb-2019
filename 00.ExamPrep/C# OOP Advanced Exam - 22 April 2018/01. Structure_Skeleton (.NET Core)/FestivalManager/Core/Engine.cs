
using System;
using System.Linq;
namespace FestivalManager.Core
{
    using System.Reflection;
    using Contracts;
    using Controllers;
    using Controllers.Contracts;
    using FestivalManager.Core.IO;
    using FestivalManager.Entities;
    using FestivalManager.Entities.Contracts;
    using IO.Contracts;

    class Engine : IEngine
    {
        private IReader reader;
        private IWriter writer;

        private IFestivalController festivalCоntroller;
        private ISetController setCоntroller;

        public Engine(IFestivalController festivalController, ISetController setCоntroller)
        {
            this.festivalCоntroller = festivalController;
            this.setCоntroller = setCоntroller;
            this.reader = new ConsoleReader();
            this.writer = new ConsoleWriter();
        }

        public void Run()
        {
            while (true)
            {
                var input = this.reader.ReadLine();

                if (input == "END")
                {
                    break;
                }

                try
                {
                    var result = this.ProcessCommand(input);
                    this.writer.WriteLine(result);
                }
                catch (Exception ex)
                {
                    this.writer.WriteLine("ERROR: " + ex.InnerException.Message);
                }
            }

            var end = this.festivalCоntroller.ProduceReport();

            this.writer.WriteLine("Results:");
            this.writer.WriteLine(end.TrimEnd());
        }

        public string ProcessCommand(string input)
        {
            var parts = input.Split(" ");

            var firstArg = parts[0];

            if (firstArg == "LetsRock")
            {
                var setResult = this.setCоntroller.PerformSets();
                return setResult;
            }

            var secondArg = parts.Skip(1).ToArray();

            var festivalcontrolfunction = this.festivalCоntroller.GetType()
                .GetMethods()
                .FirstOrDefault(x => x.Name == firstArg);

            string result;

           // try
            //{
                result = (string)festivalcontrolfunction
                    .Invoke(this.festivalCоntroller, new object[] { secondArg });
           // }
            //catch (Exception ex)
            //{
            //    writer.WriteLine(ex.Message);
            //}

            return result;
        }
    }
}