namespace P03_StudentSystem
{
    using Commands;
    using Data;
    using Students;

    public class Startup
    {
        public static void Main()
        {
            var commandParser = new CommandParser();
            var studentSystem = new StudentSystem();
            var reader = new DataReader();
            var writer = new DataWriter();

            var engine = new Engine(commandParser, studentSystem,reader,writer);

            engine.Run();
        }
    }
}
