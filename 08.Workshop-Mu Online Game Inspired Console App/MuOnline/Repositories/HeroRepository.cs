namespace MuOnline.Repositories
{
    using System.Collections.Generic;
    using System.Linq;

    using Models.Heroes.HeroContracts;
    using Repositories.Contracts;
    using Utilities;

    public class HeroRepository : IRepository<IHero>
    {
        private readonly List<IHero> heroes;
        
        public HeroRepository()
        {
            heroes = new List<IHero>();
        }

        public IReadOnlyCollection<IHero> Repository => this.heroes.AsReadOnly();

        public void Add(IHero hero)
        {
            Validator.ObjecIsNotNullValidation(hero);
            this.heroes.Add(hero);
        }

        public IHero Get(string username)
        {
            
            var targetHero = this.heroes.FirstOrDefault(x => ((IIdentifiable)x).Username == username);

            Validator.ObjecIsNotNullValidation(targetHero);

            return targetHero; 
        }

        public bool Remove(IHero hero)
        {
            Validator.ObjecIsNotNullValidation(hero);

            return this.heroes.Remove(hero);
        }
    }
}
