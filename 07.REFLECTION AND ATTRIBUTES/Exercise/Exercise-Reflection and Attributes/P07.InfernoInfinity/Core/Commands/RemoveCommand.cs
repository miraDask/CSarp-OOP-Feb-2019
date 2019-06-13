namespace P07.InfernoInfinity.Core.Commands
{
    using P07.InfernoInfinity.Data;

    public class RemoveCommand : Command
    {
        private IWeaponRepository weaponRepository;

        public RemoveCommand(string[] data, IWeaponRepository weaponRepository)
            : base(data)
        {
            this.WeaponRepository = weaponRepository;
        }

        public IWeaponRepository WeaponRepository { get => this.weaponRepository; private set => this.weaponRepository = value; }

        public override void Execute()
        {
            var nameOfWeapon = this.Data[1];

            var weapon = this.WeaponRepository.GetWeapon(nameOfWeapon);

            if (weapon != null)
            {
                var indexOfSocket = int.Parse(this.Data[2]);
                weapon.RemoveGem(indexOfSocket);
            }
        }
    }
}
