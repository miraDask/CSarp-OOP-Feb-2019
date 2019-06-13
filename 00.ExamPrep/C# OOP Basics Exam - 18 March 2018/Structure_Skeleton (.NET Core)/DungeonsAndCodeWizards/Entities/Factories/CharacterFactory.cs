using DungeonsAndCodeWizards.Entities.Characters;
using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonsAndCodeWizards.Entities.Factories
{
    public class CharacterFactory
    {
        public Character GetCharacter(string characterType, string name, Faction faction)
        {
            Character character = null;

            if (characterType == "Warrior")
            {
                return new Warrior(name, faction);
            }
            else if (characterType == "Cleric")
            {
                return new Cleric(name, faction);
            }
            else
            {
                return character;
            }
        }
    }
}
