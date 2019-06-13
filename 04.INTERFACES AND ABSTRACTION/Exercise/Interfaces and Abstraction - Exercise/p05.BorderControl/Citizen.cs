namespace p05.BorderControl
{
    public class Citizen : IIdentifiable
    {
        private string name;
        private string age;

        public Citizen(string name, string age, string id)
        {
            this.name = name;
            this.age = age;
            this.Id = id;
        }

        public string Id { get; private set; }
    }
}
