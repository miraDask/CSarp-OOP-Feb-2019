﻿using DungeonsAndCodeWizards.Entities.Characters;
using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonsAndCodeWizards.Entities.Items
{
    public class HealthPotion : Item
    {
        private const int InitialWeight = 5;

        public HealthPotion() 
            : base(InitialWeight)
        {
        }

        public override void AffectCharacter(Character character)
        {
            base.AffectCharacter(character);

            character.Health += 20;
        }
    }
}
