namespace PeopleDatabasa
{
    public class Person : IPerson
    {
        public Person(string username, long id)
        {
            this.Username = username;
            this.Id = id;
        }

        public string Username { get; private set; }

        public long Id { get; private set; }
    }
}
