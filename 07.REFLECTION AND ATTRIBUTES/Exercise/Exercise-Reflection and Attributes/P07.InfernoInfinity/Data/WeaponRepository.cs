namespace P07.InfernoInfinity.Data
{
    using P07.InfernoInfinity.Models.Contracts;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    public class WeaponRepository : IWeaponRepository, IEnumerable
    {
        private List<IWeapon> weapons;

        public WeaponRepository()
        {
            this.weapons = new List<IWeapon>();
        }

        public void AddWeapon(IWeapon weapon)
        {
            this.weapons.Add(weapon);
        }

        public IEnumerator GetEnumerator()
        {
            foreach (var weapon in weapons)
            {
                yield return weapon;
            }
        }

        public IWeapon GetWeapon(string nameOfWeapon)
        {
            if (this.weapons.Any(x => x.Name == nameOfWeapon))
            {
                return this.weapons
                    .FirstOrDefault(x => x.Name == nameOfWeapon);
            }
            else
            {
                return null;
            }
        }
    }
}
