namespace p08.MilitaryElite.Soldiers
{
    using p08.MilitaryElite.Interfaces;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    public class Army : IEnumerable
    {
        public List<ISoldier> Soldiers { get; set; } = new List<ISoldier>();

        public void AddSoldier(ISoldier soldier)
        {
            this.Soldiers.Add(soldier);
        }

        public IEnumerator GetEnumerator()
        {
            foreach (var item in this.Soldiers)
            {
                yield return item;
            }
        }

        internal ISoldier GetPrivate(string id)
        {
            ISoldier @private = this.Soldiers.Where(x => x is Private).First(x => x.Id == id);
            return @private;
        }
    }
}
