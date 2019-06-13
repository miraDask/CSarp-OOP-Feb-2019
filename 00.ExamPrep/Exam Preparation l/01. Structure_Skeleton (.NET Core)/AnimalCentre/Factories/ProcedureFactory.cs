using AnimalCentre.Factories.Contracts;
using AnimalCentre.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace AnimalCentre.Factories
{
    public class ProcedureFactory : IProcedureFactory
    {
        public IProcedure CreateProcedure(string type)
        {
            var procedureType = Assembly
               .GetCallingAssembly()
               .GetTypes()
               .FirstOrDefault(x => x.Name == type);

            return (IProcedure)Activator
                    .CreateInstance(procedureType);
        }
    }
}
