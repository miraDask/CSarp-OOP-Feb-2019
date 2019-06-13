namespace PeopleDatabasa
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Database
    {
        private List<IPerson> people;

        public Database()
        {
            this.people = new List<IPerson>();
        }

        public int CollectionLength => this.people.Count;

        public void Add(IPerson person)
        {
            
            if (this.people.Any(x => x.Username == person.Username)
                || this.people.Any(x => x.Id == person.Id))
            {
                throw new InvalidOperationException();
            }

            this.people.Add(person);
        }

        public void Remove()
        {
            if (this.people.Count <= 0)
            {
                throw new InvalidOperationException();
            }

            int lastIndex = this.people.Count - 1;
            this.people.RemoveAt(lastIndex);
        }

        public IPerson FindByUsername(string username)
        {

            if (string.IsNullOrEmpty(username) || string.IsNullOrWhiteSpace(username))
            {
                throw new ArgumentNullException();
            }

            var targetPerson = this.people.FirstOrDefault(x => x.Username == username);

            if (targetPerson == null)
            {
                throw new InvalidOperationException();
            }

            return targetPerson;
        }

        public IPerson FindById(long id)
        {

            if (id < 0)
            {
                throw new ArgumentOutOfRangeException();
            }

            var targetPerson = this.people.FirstOrDefault(x => x.Id == id);

            if (targetPerson == null)
            {
                throw new InvalidOperationException();
            }

            return targetPerson;
        }

        public IPerson[] FetchAllStoredData()
        {
            var data = this.people.ToArray();
            return data;
        }
    }
}
