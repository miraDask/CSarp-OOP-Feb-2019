namespace TheTankGame.Core
{
    using System.Collections.Generic;
    using System.Linq;
    using Contracts;

    public class CommandInterpreter : ICommandInterpreter
    {
        private const string Suffix = "Add";
        private readonly IManager tankManager;

        public CommandInterpreter(IManager tankManager)
        {
            this.tankManager = tankManager;
        }

        public string ProcessInput(IList<string> inputParameters)
        {
            string command = inputParameters[0];

            inputParameters = inputParameters.Skip(1).ToList();

            string result = string.Empty;

            result = (string)this.tankManager
                .GetType()
                .GetMethods()
                .FirstOrDefault(x => x.Name.Contains(command))
                .Invoke(this.tankManager, new object[] { inputParameters });

            //string result = string.Empty;

            //switch (command)
            //{
            //    case "Vehicle":
            //        result = this.tankManager.AddVehicle(inputParameters);
            //        break;
            //    case "Part":
            //        result = this.tankManager.AddPart(inputParameters);
            //        break;
            //    case "Inspect":
            //        result = this.tankManager.Inspect(inputParameters);
            //        break;
            //    case "Battle":
            //        result = this.tankManager.Battle(inputParameters);
            //        break;
            //    case "Terminate":
            //        result = this.tankManager.Terminate(inputParameters);
            //        break;
            //}

            return result;
        }
    }
}