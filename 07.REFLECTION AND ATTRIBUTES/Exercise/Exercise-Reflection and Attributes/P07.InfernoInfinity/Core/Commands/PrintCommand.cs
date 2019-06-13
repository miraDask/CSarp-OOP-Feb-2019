namespace P07.InfernoInfinity.Core.Commands
{
    using P07.InfernoInfinity.Data;
    using System;

    public class PrintCommand : Command
    {
        private IWeaponRepository weaponRepository;

        public PrintCommand(string[] data, IWeaponRepository weaponRepository)
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
                weapon.SetTotalStatsValue();
                Console.WriteLine(weapon.ToString());
            }
        }
    }
}
