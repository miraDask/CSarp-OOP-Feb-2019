namespace p03.Mankind
{
    using System;
    using System.Text;

    public class Human
    {
        private const int lengthOfFirstName = 4;
        private const int lengthOfLastName = 3;

        private string firstName;
        private string lastName;

        public Human(string firstName, string lastName)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
        }

        public string FirstName
        {
            get => this.firstName;
            set
            {
                string typeOfName = nameof(this.firstName);
                this.FirstLetterValidation(value, typeOfName);
                this.NameLengthValidation(value, typeOfName);

                this.firstName = value;
            }
        }

        public string LastName
        {
            get => this.lastName;
            set
            {
                string typeOfName = nameof(this.lastName);
                this.FirstLetterValidation(value, typeOfName);
                this.NameLengthValidation(value, typeOfName);

                this.lastName = value;
            }
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            result.AppendLine($"First Name: {this.FirstName}");
            result.AppendLine($"Last Name: {this.LastName}");

            return result.ToString().TrimEnd();
        }

        private void FirstLetterValidation(string value, string typeOfName)
        {
            if (!char.IsUpper(value[0]))
            {
                throw new ArgumentException($"Expected upper case letter! Argument: {typeOfName}");
            }
        }

        private void NameLengthValidation(string value, string typeOfName)
        {
            int lengthOfName = typeOfName == nameof(this.firstName) ? lengthOfFirstName : lengthOfLastName;

            string lengthExeptionText = $"Expected length at least {lengthOfName} symbols! Argument: {typeOfName}";
            
            if (value.Length < lengthOfName || string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException(lengthExeptionText);
            }
        }
    }
}
