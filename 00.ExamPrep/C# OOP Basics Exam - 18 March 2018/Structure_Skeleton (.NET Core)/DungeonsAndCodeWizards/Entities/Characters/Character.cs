using DungeonsAndCodeWizards.Entities.Bags;
using DungeonsAndCodeWizards.Entities.Items;
using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonsAndCodeWizards.Entities.Characters
{
    public abstract class Character
    {
        private const double DefaultRestHealMultiplier = 0.2;
        private string name;
        private double health;
        private double armor;

        protected Character(string name, double health, double armor, double abilityPoints, Bag bag, Faction faction)
        {
            this.Name = name;
            this.BaseHealth = health;
            this.health = this.BaseHealth;
            this.BaseArmor = armor;
            this.armor = this.BaseArmor;
            this.AbilityPoints = abilityPoints;
            this.Bag = bag;
            this.Faction = faction;
            this.IsAlive = true;
            this.RestHealMultiplier = DefaultRestHealMultiplier;
        }

        public string Name
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name cannot be null or whitespace!");
                }

                this.name = value;
            }
        }

        public double BaseHealth { get; private set; }

        public double BaseArmor { get; private set; }

        public double Health
        {
            get => this.health;
            set => this.health = Math.Min(Math.Max(value, 0), this.BaseHealth);
        }

        public double Armor
        {
            get => this.armor;
            set => this.armor = Math.Min(Math.Max(value, 0), this.BaseArmor);
        }

        public double AbilityPoints { get; private set; }

        public Bag Bag { get; private set; }

        public Faction Faction { get; private set; }

        public bool IsAlive { get; set; }

        public double RestHealMultiplier { get; protected set; }

        public void TakeDamage(double hitPoints)
        {
            IsAliveValidation(this);
            var armorLeft = this.Armor;

            this.Armor -= hitPoints;

            if (this.Armor == 0)
            {
                hitPoints -= armorLeft;
                this.Health -= hitPoints;
            }

            if (this.Health == 0)
            {
                this.IsAlive = false;
            }
        }
       
        public void Rest()
        {
            IsAliveValidation(this);
            this.Health = this.Health + (this.BaseHealth * this.RestHealMultiplier);
        }

        public void UseItem(Item item)
        {
            IsAliveValidation(this);
            item.AffectCharacter(this);
        }

        public void UseItemOn(Item item, Character character)
        {
            IsAliveValidation(this);
            IsAliveValidation(character);
            
            item.AffectCharacter(character);
        }

        public void GiveCharacterItem(Item item, Character character)
        {
            IsAliveValidation(this);
            IsAliveValidation(character);
            character.ReceiveItem(item);
        }

        public void ReceiveItem(Item item)
        {
            IsAliveValidation(this);
            this.Bag.AddItem(item);
        }

        protected void IsAliveValidation(Character character)
        {
            if (!character.IsAlive)
            {
                throw new InvalidOperationException("Must be alive to perform this action!");
            }
        }
    }
}
