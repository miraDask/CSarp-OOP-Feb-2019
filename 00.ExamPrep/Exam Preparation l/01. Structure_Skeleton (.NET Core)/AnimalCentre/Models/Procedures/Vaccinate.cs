using System;
using System.Collections.Generic;
using System.Text;
using AnimalCentre.Models.Contracts;

namespace AnimalCentre.Models.Procedures
{
    public class Vaccinate : Procedure
    {
        private const int EnergyDecreasment = 8;

        public override void DoService(IAnimal animal, int procedureTime)
        {
            base.DoService(animal, procedureTime);

            animal.ProcedureTime -= procedureTime;
            animal.Energy -= EnergyDecreasment;
            animal.IsVaccinated = true;

            var procedure = this.GetType().Name;
            this.ProcedureHistory.Add(animal);
        }
    }
}
