using AnimalCentre.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace AnimalCentre.Factories.Contracts
{
    public interface IProcedureFactory
    {
        IProcedure CreateProcedure(string type); 
    }
}
