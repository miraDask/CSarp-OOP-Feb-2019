using AnimalCentre.Factories;
using AnimalCentre.Factories.Contracts;
using AnimalCentre.Models;
using AnimalCentre.Models.Contracts;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AnimalCentre.Core
{
    public class AnimalCentre
    {
        private Dictionary<string, List<string>> owners;
        private IAnimalFactory animalFactory;
        private IProcedureFactory procedureFactory;
        private IHotel hotel;
        private ICollection<IProcedure> procedures;

        public AnimalCentre()
        {
            this.animalFactory = new AnimalFactory();
            this.procedureFactory = new ProcedureFactory();
            this.hotel = new Hotel();
            this.owners = new Dictionary<string, List<string>>();
            this.procedures = new List<IProcedure>();
        }
        
        public string RegisterAnimal(string[] args)
        {
            string type = args[0];
            string name = args[1];
            int energy = int.Parse(args[2]);
            int happiness = int.Parse(args[3]);
            int procedureTime = int.Parse(args[4]);

            var animal = this.animalFactory.CreateAnimal(type, name, energy, happiness, procedureTime);
             this.hotel.Accommodate(animal);

            return $"Animal {animal.Name} registered successfully";
        }

        public string Chip(string[] args)
        {
            string name = args[0];
            int procedureTime = int.Parse(args[1]);
            var animal = this.hotel.Animals[name];
            var procedure = this.procedureFactory.CreateProcedure("Chip");
            procedure.DoService(animal, procedureTime);
            this.procedures.Add(procedure);
            return $"{name} had chip procedure";
        }

        public string Vaccinate(string[] args)
        {
            string name = args[0];
            int procedureTime = int.Parse(args[1]);

            var animal = this.hotel.Animals[name];
            var procedure = this.procedureFactory.CreateProcedure("Vaccinate");
            procedure.DoService(animal, procedureTime);
            this.procedures.Add(procedure);

            return $"{name} had vaccination procedure";
        }

        public string Fitness(string[] args)
        {
            string name = args[0];
            int procedureTime = int.Parse(args[1]);

            var animal = this.hotel.Animals[name];
            var procedure = this.procedureFactory.CreateProcedure("Fitness");
            procedure.DoService(animal, procedureTime);
            this.procedures.Add(procedure);

            return $"{name} had fitness procedure";
        }

        public string Play(string[] args)
        {
            string name = args[0];
            int procedureTime = int.Parse(args[1]);

            var animal = this.hotel.Animals[name];
            var procedure = this.procedureFactory.CreateProcedure("Play");
            procedure.DoService(animal, procedureTime);
            this.procedures.Add(procedure);

            return $"{name} was playing for {procedureTime} hours";
        }

        public string DentalCare(string[] args)
        {
            string name = args[0];
            int procedureTime = int.Parse(args[1]);

            var animal = this.hotel.Animals[name];
            var procedure = this.procedureFactory.CreateProcedure("DentalCare");
            procedure.DoService(animal, procedureTime);
            this.procedures.Add(procedure);

            return $"{name} had dental care procedure";
        }

        public string NailTrim(string[] args)
        {
            string name = args[0];
            int procedureTime = int.Parse(args[1]);
            var animal = this.hotel.Animals[name];
            var procedure = this.procedureFactory.CreateProcedure("NailTrim");
            procedure.DoService(animal, procedureTime);
            this.procedures.Add(procedure);

            return $"{name} had nail trim procedure";
        }

        public string Adopt(string[] args)
        {
            string animalName = args[0];
            string owner = args[1];
            var animal = this.hotel.Animals[animalName];

             this.hotel.Adopt(animalName, owner);


            if (!this.owners.ContainsKey(owner))
            {
                this.owners[owner] = new List<string>();
            }

            this.owners[owner].Add(animalName);

            if (animal.IsChipped)
            {
                return $"{owner} adopted animal with chip";
            }
            else
            {
                return $"{owner} adopted animal without chip";
            }
        }

        public string History(string[] args)
        {
            string typeOfProcedure = args[0];
            var procedure = this.procedures.FirstOrDefault(x => x.GetType().Name == typeOfProcedure);

            return procedure.History();
        }

        public string End()
        {
            StringBuilder result = new StringBuilder();

            foreach (var kvp in owners)
            {
                result.AppendLine($"--Owner: {kvp.Key}");
                result.AppendLine($"    - Adopted animals: {string.Join(" ", kvp.Value)}");
            }

            return result.ToString().TrimEnd();
        }
    }
}
