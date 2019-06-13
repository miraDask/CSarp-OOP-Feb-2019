﻿namespace p06.BirthdayCelebrations
{
    public class Pet : INameble, IBirthable
    {
        public Pet(string name, string birthdate)
        {
            this.Name = name;
            this.Birthdate = birthdate;
        }

        public string Name { get; private set; }

        public string Birthdate { get; private set; }

    }
}
