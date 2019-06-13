namespace SimpleSnake.GameObjects.Contracts
{
    using System.Collections.Generic;

    public interface ILevel
    {
        int Number { get; }

        int StartingPoints { get; }

        IReadOnlyCollection<ICoordinate> Obstacles { get; }
    }
}
