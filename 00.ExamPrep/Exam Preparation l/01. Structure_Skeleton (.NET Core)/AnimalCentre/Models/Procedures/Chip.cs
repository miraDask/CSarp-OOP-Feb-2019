using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AnimalCentre.Models.Contracts;

namespace AnimalCentre.Models.Procedures
{
    public class Chip : Procedure
    {
        private const int HappinessDecreasment = 5;

        public override void DoService(IAnimal animal, int procedureTime)
        {
            base.DoService(animal, procedureTime);

            if (animal.IsChipped == true)
            {
                throw new ArgumentException($"{animal.Name} is already chipped");
            }

            animal.ProcedureTime -= procedureTime;
            animal.IsChipped = true;
            animal.Happiness -= HappinessDecreasment;
            var procedure = this.GetType().Name;

            this.ProcedureHistory.Add(animal);
        }
    }
}
