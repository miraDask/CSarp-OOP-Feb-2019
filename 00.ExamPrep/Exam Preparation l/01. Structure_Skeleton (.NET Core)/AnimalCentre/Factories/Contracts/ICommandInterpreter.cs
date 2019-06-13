using System;
using System.Collections.Generic;
using System.Text;

namespace AnimalCentre.Factories.Contracts
{
    public interface ICommandInterpreter
    {
        string Read(string[] args);
    }
}
