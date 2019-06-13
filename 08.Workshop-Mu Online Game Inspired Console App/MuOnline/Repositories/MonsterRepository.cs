namespace MuOnline.Repositories
{
    using System.Collections.Generic;
    using System.Linq;

    using Models.Monsters.Contracts;
    using Repositories.Contracts;
    using Utilities;

    public class MonsterRepository : IRepository<IMonster>
    {
        private readonly List<IMonster> monsters;

        public MonsterRepository()
        {
            this.monsters = new List<IMonster>();
        }

        public IReadOnlyCollection<IMonster> Repository => this.monsters.AsReadOnly();

        public void Add(IMonster monster)
        {
            Validator.ObjecIsNotNullValidation(monster);
            this.monsters.Add(monster);
        }

        public IMonster Get(string monster)
        {
            monster = monster.ToLower();

            var targetMonster = this.monsters.FirstOrDefault(x => x.GetType().Name.ToLower() == monster);

            Validator.ObjecIsNotNullValidation(targetMonster);

            return targetMonster;
        }

        public bool Remove(IMonster monster)
        {
            Validator.ObjecIsNotNullValidation(monster);

            return this.monsters.Remove(monster);
        }
    }
}
