using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DungeonsAndCodeWizards.Core
{
    public class Engine
    {
        private DungeonMaster controller;
        private bool isRunning;

        public Engine()
        {
            this.controller = new DungeonMaster();
            this.isRunning = false;
        }

        public void Run()
        {
            this.isRunning = true;

            while (this.isRunning)
            {
                var input = Console.ReadLine().Split();
                var command = input[0];
                var args = input.Skip(1).ToArray();




                try
                {
                    string result = (string)this.controller
                   .GetType()
                   .GetMethods()
                   .FirstOrDefault(m => m.Name.Contains(command))
                   .Invoke(this.controller, new object[] { args });

                    Console.WriteLine(result);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.InnerException.Message);
                }

                bool isEnding = this.controller.IsGameOver();

                if (isEnding)
                {
                    this.isRunning = false;
                    Console.WriteLine(this.controller.GetStats());
                    continue;
                }
            }
        }
    }
}
