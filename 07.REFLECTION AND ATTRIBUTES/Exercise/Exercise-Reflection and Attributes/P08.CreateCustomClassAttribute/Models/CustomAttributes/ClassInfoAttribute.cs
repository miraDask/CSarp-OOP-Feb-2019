namespace P07.InfernoInfinity.Models.CustomAttributes
{
    using System;

    [AttributeUsage(AttributeTargets.Class)]
    public class ClassInfoAttribute : Attribute
    {
        public ClassInfoAttribute(string author, int revision, string description, params string[] reviewers)
        {
            this.Author = author;
            this.Revision = revision;
            this.Description = description;
            this.Reviewers = reviewers;
        }

        public string Author { get; private set; }

        public int Revision { get; private set; }

        public string Description { get; private set; }

        public string[] Reviewers { get; private set; }
    }
}
