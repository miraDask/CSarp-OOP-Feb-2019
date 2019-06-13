namespace P07.InfernoInfinity.Core.Commands
{
    using P07.InfernoInfinity.Data;
    using P07.InfernoInfinity.Models.Contracts;

    public class CreateCommand : Command
    {
        private IWeaponRepository weaponRepository;
        private IWeaponFactory weaponFactory;

        public CreateCommand(string[] data, IWeaponRepository weaponRepository, IWeaponFactory weaponFactory)
            : base(data)
        {
            this.WeaponRepository = weaponRepository;
            this.WeaponFactory = weaponFactory;
        }

        public IWeaponRepository WeaponRepository { get => this.weaponRepository; private set => this.weaponRepository = value; }

        public IWeaponFactory WeaponFactory { get => this.weaponFactory; private set => this.weaponFactory = value; }

        public override void Execute()
        {
            var weaponArgs = this.Data[1].Split();
            var rarityType = weaponArgs[0];
            var typeOfWeapon = weaponArgs[1];

            var nameOfWeapon = this.Data[2];

            var weapon = this.WeaponFactory.CreateWeapon(typeOfWeapon, nameOfWeapon, rarityType);

            this.WeaponRepository.AddWeapon(weapon);
        }
    }
}
