using AnimalCentre.Models.Contracts;
using System.Collections.Generic;

namespace AnimalCentre.Models.Procedures
{
    public class Fitness : Procedure
    {
        private const int HappinessDecreasment = 3;
        private const int EnergyIncreasment = 10;

        public override void DoService(IAnimal animal, int procedureTime)
        {
            base.DoService(animal, procedureTime);

            animal.ProcedureTime -= procedureTime;
            animal.Happiness -= HappinessDecreasment;
            animal.Energy += EnergyIncreasment;

            var procedure = this.GetType().Name;
            this.ProcedureHistory.Add(animal);

        }
    }
}
