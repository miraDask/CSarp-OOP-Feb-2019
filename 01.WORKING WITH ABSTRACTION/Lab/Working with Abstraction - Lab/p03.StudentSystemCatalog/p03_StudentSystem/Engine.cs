namespace P03_StudentSystem
{
    using Commands;
    using Data;
    using Students;

    public class Engine
    {
        private CommandParser commandParser;
        private StudentSystem studentSystem;
        private DataReader reader;
        private DataWriter writer;

        public Engine(CommandParser commandParser
            , StudentSystem studentSystem
            ,DataReader reader
            ,DataWriter writer)
        {
            this.commandParser = commandParser;
            this.studentSystem = studentSystem;
            this.reader = reader;
            this.writer = writer;
        }

        public void Run()
        {
            while (true)
            {
                var command = this.commandParser.Parse(this.reader.Read());

                if (command.Name == "Create")
                {
                    var name = command.Arguments[0];
                    var age = int.Parse(command.Arguments[1]);
                    var grade = double.Parse(command.Arguments[2]);

                    studentSystem.Add(name, age, grade);
                }
                else if (command.Name == "Show")
                {
                    var name = command.Arguments[0];

                    try
                    {
                        var student = studentSystem.Get(name);
                        this.writer.Write(student);

                    }
                    catch
                    {
                        continue;
                    }
                }
                else if (command.Name == "Exit")
                {
                    break;
                }
            }
        }
    }
}
