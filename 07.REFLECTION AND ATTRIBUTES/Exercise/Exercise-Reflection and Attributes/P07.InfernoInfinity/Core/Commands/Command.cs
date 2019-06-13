namespace P07.InfernoInfinity.Core.Commands
{
    using P07.InfernoInfinity.Core.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Text;
    

    public abstract class Command : IExecutable
    {

        protected Command(string[] data)
        {
            this.Data = data;
        }

        protected string[] Data { get; }

        public abstract void Execute();
        
    }
}
