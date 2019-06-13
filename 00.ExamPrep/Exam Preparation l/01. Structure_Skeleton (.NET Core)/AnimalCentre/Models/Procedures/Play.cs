using System;
using System.Collections.Generic;
using System.Text;
using AnimalCentre.Models.Contracts;

namespace AnimalCentre.Models.Procedures
{
    public class Play : Procedure
    {
        private const int HappinessIncreasment = 12;
        private const int EnergyDecreasment = 6;

        public override void DoService(IAnimal animal, int procedureTime)
        {
            base.DoService(animal, procedureTime);
            animal.ProcedureTime -= procedureTime;
            animal.Happiness += HappinessIncreasment;
            animal.Energy -= EnergyDecreasment;

            var procedure = this.GetType().Name;

            this.ProcedureHistory.Add(animal);
        }
    }
}
