namespace AnimalCentre.Models.Contracts
{
    using System.Collections.Generic;

    public interface IHotel
    {
        //•	Capacity – int with a constant value of 10 
        //•	Animals – Collection with the animal’s name as the key and the animal itself as the value
        //int Capacity { get;}

        IReadOnlyDictionary<string, IAnimal> Animals { get; }

        void Accommodate(IAnimal animal);

        void Adopt(string animalName, string owner);
    }
}
