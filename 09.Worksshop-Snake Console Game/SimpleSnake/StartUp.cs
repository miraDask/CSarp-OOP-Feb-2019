namespace SimpleSnake
{
    using SimpleSnake.Constants;
    using SimpleSnake.Core;
    using SimpleSnake.GameObjects;
    using SimpleSnake.GameObjects.Herroes;
    using SimpleSnake.GameObjects.Levels;
    using Utilities;

    public class StartUp
    {
        public static void Main()
        {
            ConsoleWindow.CustomizeConsole();
            var manager = new DrawManager();
            var snake = new Snake();
            var level = new Level_1();
            var engine = new Engine(snake, manager, level);
            engine.Run();
        }
    }
}
