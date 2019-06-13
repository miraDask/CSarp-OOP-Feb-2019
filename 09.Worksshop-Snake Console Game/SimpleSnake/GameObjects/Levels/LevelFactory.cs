namespace SimpleSnake.GameObjects.Levels
{
    using SimpleSnake.GameObjects.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Text;

    public class LevelFactory
    {
        public ILevel GetLevel(int levelNumber)
        {
            var type = Assembly
                .GetExecutingAssembly()
                .GetTypes()
                .FirstOrDefault(x => x.Name.Contains(levelNumber.ToString()));

            return (ILevel)Activator.CreateInstance(type);
        }

    }
}
