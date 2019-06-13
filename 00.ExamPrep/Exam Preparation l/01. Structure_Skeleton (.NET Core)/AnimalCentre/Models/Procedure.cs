using AnimalCentre.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace AnimalCentre.Models
{
    public abstract class Procedure : IProcedure
    {

        protected Procedure()
        {
            this.ProcedureHistory = new List<IAnimal>();
        }

        protected ICollection<IAnimal> ProcedureHistory { get; set; }
        

        public virtual void DoService(IAnimal animal, int procedureTime)
        {
            if (procedureTime > animal.ProcedureTime)
            {
                throw new ArgumentException("Animal doesn't have enough procedure time");
            }
        }
        
        public string History()
        {
            StringBuilder result = new StringBuilder();

            string procedure = this.GetType().Name;

            result.AppendLine($"{procedure}");

            foreach (var animal in this.ProcedureHistory)
            {
                result.AppendLine($"    Animal type: {animal.GetType().Name} - {animal.Name} - Happiness: {animal.Happiness} - Energy: {animal.Energy}");
            }

            return result.ToString().TrimEnd();
        }
    }
}
