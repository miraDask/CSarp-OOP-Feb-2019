﻿namespace _03BarracksFactory.Core.Commands
{
    using _03BarracksFactory.Contracts;
    using System;

    class FightCommand : Command
    {
        public FightCommand(string[] data, IRepository repository, IUnitFactory unitFactory)
            : base(data, repository, unitFactory)
        {
        }

        public override string Execute()
        {
            Environment.Exit(0);
            return string.Empty;
        }
    }
}
