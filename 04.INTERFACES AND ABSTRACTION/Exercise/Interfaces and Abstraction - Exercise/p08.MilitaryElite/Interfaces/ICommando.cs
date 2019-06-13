namespace p08.MilitaryElite.Interfaces
{
    using System.Collections.Generic;

    public interface ICommando
    {
        List<Mission> Missions { get; }

        void CompleteMission(Mission mission);
    }
}
