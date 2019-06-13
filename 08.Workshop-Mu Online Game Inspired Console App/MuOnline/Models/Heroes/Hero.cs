namespace MuOnline.Models.Heroes
{
    using System.Linq;

    using HeroContracts;
    using Inventories;
    using Inventories.Contracts;
    using Utilities;

    public abstract class Hero : IHero, IIdentifiable, IProgress
    {
        private string username;
        private int strength;
        private int agility;
        private int stamina;
        private int energy;
        private int experience;
        private int level;
        private int resets;

        protected Hero(
            string username,
            int strength, int agility, int stamina, int energy)
        {
            this.Inventory = new Inventory();
            this.Username = username;
            this.Strength = strength;
            this.Agility = agility;
            this.Stamina = stamina;
            this.Energy = energy;
            this.Experience = 0;
            this.Level = 0;
            this.Resets = 0;
            this.TotalStaminaPoints = GetTotalStaminaPoints();
            this.TotalAgilityPoints = GetTotalAgilityPoints();
            this.TotalEnergyPoints = GetTotalEnergyPoints();
            this.TotalAttackPoints = GetTotalAttackPoints();
        }

        public IInventory Inventory { get; }

        public bool IsAlive
            => this.TotalStaminaPoints > 0;


        public int TotalAgilityPoints { get; private set; }

        public int TotalStaminaPoints { get; private set; }

        public int TotalAttackPoints { get; private set; }

        public int TotalEnergyPoints { get; private set; }

        public string Username
        {
            get
            {
                return this.username;
            }
            private set
            {
                Validator.ValidateStringArgValue(nameof(this.Username));
                    
                this.username = value;
            }
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

        public int Experience
        {
            get
            {
                return this.experience;
            }
            private set
            {
                Validator.ValidateIntArgValue(value, nameof(this.Experience));

                this.experience = value;
            }
        }

        public int Level
        {
            get
            {
                return this.level;
            }
            private set
            {
                Validator.ValidateIntArgValue(value, nameof(this.Level));

                this.level = value;
            }
        }

        public int Resets
        {
            get
            {
                return this.resets;
            }
            private set
            {
                Validator.ValidateIntArgValue(value, nameof(this.Resets));

                this.resets = value;
            }
        }

        public void TakeDamage(int damagePoints)
        {
            if (this.TotalAgilityPoints > 0)
            {
                this.TotalAgilityPoints -= damagePoints;
            }
            else
            {
                this.TotalStaminaPoints -= damagePoints;
            }
        }

        public void AddExperience(int experience)
        {

            Validator.IsAliveValidation(this.IsAlive);

            this.Experience += experience;

            if (this.Experience >= 9000)
            {
                AddLevel();
            }

            if (this.Level >= 400)
            {
                AddReset();
            }
        }

        private void AddReset()
        {
            this.Resets++;
            // this.Level = 0; ?
        }

        private void AddLevel()
        {
            this.Level++;
            this.Experience = 0;
        }

        private int GetTotalStaminaPoints()
        {
            return this.TotalStaminaPoints = this.Stamina +
                    this.Inventory.Items.Sum(x => x.Stamina);
        }

        private int GetTotalAgilityPoints()
        {
            return this.TotalAgilityPoints = this.Agility +
                    this.Inventory.Items.Sum(x => x.Agility);
        }

        private int GetTotalEnergyPoints()
        {
            return this.Energy +
               this.Inventory.Items.Sum(x => x.Energy);
        }

        private int GetTotalAttackPoints()
        {
            return this.Strength +
                   this.Agility * 10 / 100 +
                   this.Energy * 5 / 100 +
                   this.Inventory.Items.Sum(x => x.Strength);
        }
    }
}
