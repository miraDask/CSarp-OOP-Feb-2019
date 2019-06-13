using System;
using System.Collections.Generic;
using System.Text;
using AnimalCentre.Models.Contracts;

namespace AnimalCentre.Models.Procedures
{
    public class NailTrim : Procedure
    {
        private const int HappinessDecreasment = 7;

        public override void DoService(IAnimal animal, int procedureTime)
        {
            base.DoService(animal, procedureTime);
            animal.ProcedureTime -= procedureTime;
            animal.Happiness -= HappinessDecreasment;

            var procedure = this.GetType().Name;
            this.ProcedureHistory.Add(animal);

        }
    }
}
