namespace P07.InfernoInfinity.Data
{
    using P07.InfernoInfinity.Models.Contracts;
    using System.Collections;

    public interface IWeaponRepository : IEnumerable
    {
        void AddWeapon(IWeapon weapon);

        IWeapon GetWeapon(string nameOfWeapon);
    }
}
