using System;
using System.Collections.Generic;
using System.Text;
using AnimalCentre.Models.Contracts;

namespace AnimalCentre.Models.Procedures
{
    public class DentalCare : Procedure
    {
        private const int HappinessIncreasment = 12;
        private const int EnergyIncreasment = 10;

        public override void DoService(IAnimal animal, int procedureTime)
        {
            base.DoService(animal, procedureTime);

            animal.ProcedureTime -= procedureTime;
            animal.Happiness += HappinessIncreasment;
            animal.Energy += EnergyIncreasment;

            var procedure = this.GetType().Name;

            this.ProcedureHistory.Add(animal);
        }
    }
}
