namespace P07_FamilyTree
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Person
    {
        private string name;
        private string birthday;
        private List<Person> parents;
        private List<Person> children;

        public Person()
        {
            this.Children = new List<Person>();
            this.Parents = new List<Person>();
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string Birthday
        {
            get { return birthday; }
            set { birthday = value; }
        }

        public List<Person> Parents
        {
            get { return parents; }
            set { parents = value; }
        }

        public List<Person> Children
        {
            get { return children; }
            set { children = value; }
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            result.AppendLine($"{this.Name} {this.Birthday}");
            result.AppendLine($"Parents:");

            if (this.Parents.Any())
            {
                foreach (var parent in Parents)
                {
                    result.AppendLine($"{parent.Name} {parent.Birthday}");
                }
            }

            result.AppendLine($"Children:");

            if (this.Children.Any())
            {
                foreach (var child in Children)
                {
                    result.AppendLine($"{child.Name} {child.Birthday}");
                }
            }

            return result.ToString().TrimEnd();
        }

    }

}

