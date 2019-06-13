namespace p03.Mankind
{
    using System;
    using System.Text;
    using System.Text.RegularExpressions;

    public class Student : Human
    {
        private string facultyNumber;

        public Student(string firstName, string lastName, string facultyNumber)
            : base(firstName, lastName)
        {
            this.FacultyNumber = facultyNumber;
        }

        public string FacultyNumber
        {
            get => this.facultyNumber;
            set
            {
                this.FacultyNumberValidation(value);

                this.facultyNumber = value;
            }
        }

        private void FacultyNumberValidation(string value)
        {
            string pattern = @"^[a-zA-z\d]{5,10}$";
            Match match = Regex.Match(value,pattern);

            if (!match.Success)
            {
                throw new ArgumentException("Invalid faculty number!");
            }
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            result.AppendLine(base.ToString());
            result.AppendLine($"Faculty number: {this.FacultyNumber}");
           
            return result.ToString().TrimEnd();
        }
    }
}

