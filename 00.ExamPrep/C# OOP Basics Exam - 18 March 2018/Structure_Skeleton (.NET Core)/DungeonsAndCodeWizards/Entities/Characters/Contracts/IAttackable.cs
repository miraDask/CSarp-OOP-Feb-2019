using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonsAndCodeWizards.Entities.Characters.Contracts
{
    public interface IAttackable
    {
        string Name { get; }
        void Attack(Character character);
    }
}
