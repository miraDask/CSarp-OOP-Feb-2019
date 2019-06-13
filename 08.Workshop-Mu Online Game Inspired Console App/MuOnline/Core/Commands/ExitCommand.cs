namespace MuOnline.Core.Commands
{
    using Core.Commands.Contracts;
    using System;

    public class ExitCommand : ICommand
    {
        public string Execute(string[] inputArgs)
        {
            Environment.Exit(0);
            return null;
        }
    }
}
