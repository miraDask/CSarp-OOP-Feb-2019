
namespace SimpleSnake.GameObjects.Contracts
{
    using SimpleSnake.Enums;
    using System.Collections.Generic;

    public interface IHero
    {
        string Symbol { get; set; }

        Direction CurrentDirection { get; set; }

        ICoordinate Head { get; set; }

        IReadOnlyCollection<ICoordinate> Body { get; }

        void InitializeDefaultSnake();

        ICoordinate CalculateNewCoordinate(ICoordinate newCoordinate);

        void Move();

        void Eat(IFood food);

    }
}
