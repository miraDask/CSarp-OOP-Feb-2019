namespace P07.InfernoInfinity.Models.Contracts
{
    public interface IWeaponFactory
    {
        IWeapon CreateWeapon(string typeOfWeapon, string name, string rarityType);
    }
}