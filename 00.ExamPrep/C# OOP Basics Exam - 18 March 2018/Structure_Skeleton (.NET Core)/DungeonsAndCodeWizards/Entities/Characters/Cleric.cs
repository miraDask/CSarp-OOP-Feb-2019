using DungeonsAndCodeWizards.Entities.Bags;
using DungeonsAndCodeWizards.Entities.Characters.Contracts;
using System;

namespace DungeonsAndCodeWizards.Entities.Characters
{
    public class Cleric : Character, IHealable
    {
        private const double ClericRestHealMultiplier = 0.5;

        public Cleric(string name, Faction faction)
            : base(name, 50, 25, 40, new Backpack(), faction)
        {
            base.RestHealMultiplier = ClericRestHealMultiplier;
        }

        public void Heal(Character character)
        {
            IsAliveValidation(this);
            IsAliveValidation(character);

            if (character.Faction != this.Faction)
            {
                throw new InvalidOperationException("Cannot heal enemy character!");
            }

            character.Health += this.AbilityPoints;
        }
    }
}
