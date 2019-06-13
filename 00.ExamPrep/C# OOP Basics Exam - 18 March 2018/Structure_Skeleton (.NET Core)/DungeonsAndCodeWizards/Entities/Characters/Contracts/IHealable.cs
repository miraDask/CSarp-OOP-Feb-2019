using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonsAndCodeWizards.Entities.Characters.Contracts
{
    public interface IHealable
    {
        string Name { get; }

        void Heal(Character character);
    }
}
