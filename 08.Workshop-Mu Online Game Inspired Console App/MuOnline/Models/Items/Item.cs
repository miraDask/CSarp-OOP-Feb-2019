namespace MuOnline.Models.Items
{
    using Contracts;
    using Utilities;

    public abstract class Item : IItem
    {
        private int strength;
        private int agility;
        private int stamina;
        private int energy;

        protected Item(int strength, int agility, int stamina, int energy)
        {
            this.Strength = strength;
            this.Agility = agility;
            this.Stamina = stamina;
            this.Energy = energy;
        }

        public int Strength
        {
            get
            {
                return this.strength;
            }
            private set
            {
                Validator.ValidateIntArgValue(value, nameof(this.Strength));

                this.strength = value;
            }
        }

        public int Agility
        {
            get
            {
                return this.agility;
            }
            private set
            {
                Validator.ValidateIntArgValue(value, nameof(this.Agility));

                this.agility = value;
            }
        }

        public int Stamina
        {
            get
            {
                return this.stamina;
            }
            private set
            {
                Validator.ValidateIntArgValue(value, nameof(this.Stamina));

                this.stamina = value;
            }
        }

        public int Energy
        {
            get
            {
                return this.energy;
            }
            private set
            {
                Validator.ValidateIntArgValue(value, nameof(this.Energy));

                this.energy = value;
            }
        }
    }
}
