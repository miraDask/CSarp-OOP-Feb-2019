namespace p06.BirthdayCelebrations
{
    public class Citizen : IIdentifiable, INameble, IBirthable
    {
        private string age;

        public Citizen(string name, string age, string id, string birthdate)
        {
            this.Name = name;
            this.age = age;
            this.Id = id;
            this.Birthdate = birthdate;
        }

        public string Id { get; private set; }

        public string Name { get; private set; }

        public string Birthdate { get; private set; }

    }
}
