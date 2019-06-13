﻿namespace _03BarracksFactory.Core.Commands
{
    using _03BarracksFactory.Contracts;

    public abstract class Command : IExecutable
    {
        protected Command(string[] data, IRepository repository, IUnitFactory unitFactory)
        {
            this.Data = data;
            this.Repository = repository;
            this.UnitFactory = unitFactory;
        }

        protected string[] Data { get; }

        protected IRepository Repository { get; }

        protected IUnitFactory UnitFactory { get; }

        public abstract string Execute();
        
    }
}
