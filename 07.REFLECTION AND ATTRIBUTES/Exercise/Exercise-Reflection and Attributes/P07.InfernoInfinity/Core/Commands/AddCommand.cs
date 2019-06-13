namespace P07.InfernoInfinity.Core.Commands
{
    using P07.InfernoInfinity.Data;
    using P07.InfernoInfinity.Models.Contracts;
    using System;

    public class AddCommand : Command
    {
        private IWeaponRepository weaponRepository;
        private IGemFactory gemFactory;

        public AddCommand(string[] data, IWeaponRepository weaponRepository, IGemFactory gemFactory)
            : base(data)
        {
            this.WeaponRepository = weaponRepository;
            this.GemFactory = gemFactory;
        }

        public IWeaponRepository WeaponRepository { get => this.weaponRepository; private set => this.weaponRepository = value; }

        public IGemFactory GemFactory { get => this.gemFactory; private set => this.gemFactory = value; }

        public override void Execute()
        {
            var nameOfWeapon = this.Data[1];

            var weapon = this.WeaponRepository.GetWeapon(nameOfWeapon);

            if (weapon != null)
            {
                var gemArgs = this.Data[3].Split();
                string gemClarity = gemArgs[0];
                string gemType = gemArgs[1];
                var clarity = Enum.Parse<Clarity>(gemClarity);
                var gem = this.GemFactory.CreateGem(gemType, clarity);
                var indexOfSocket = int.Parse(this.Data[2]);
                weapon.AddGem(gem, indexOfSocket);
            }
        }
    }
}
