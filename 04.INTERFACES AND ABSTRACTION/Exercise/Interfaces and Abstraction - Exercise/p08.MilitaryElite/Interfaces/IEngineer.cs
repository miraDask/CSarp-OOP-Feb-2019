namespace p08.MilitaryElite.Interfaces
{
    using System.Collections.Generic;

    public interface IEngineer
    {
        List<Repair> Repairs { get; }
    }
}
