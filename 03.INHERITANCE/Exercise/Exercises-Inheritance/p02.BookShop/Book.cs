namespace p02.BookShop
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Book
    {
        private string title;
        private string author;
        private decimal price;

        public Book(string author, string title, decimal price)
        {
            this.Author = author;
            this.Title = title;
            this.Price = price;
        }

        public string Title
        {
            get => this.title;
            set
            {
                if (value.Length < 3)
                {
                    throw new ArgumentException("Title not valid!");
                }

                this.title = value;
            }
        }

        public string Author
        {
            get => this.author;
            set
            {
                CheckFirstSymbolOfSecondName(value);

                this.author = value;
            }
        }

        public virtual decimal Price
        {
            get => this.price;
            set
            {
                if (value < 1)
                {
                    throw new ArgumentException("Price not valid!");
                }

                this.price = value;
            }
        }

        private void CheckFirstSymbolOfSecondName(string value)
        {
            int indexOfWhiteSpace = value.IndexOf(' ');

            if (value.Contains(' ') && char.IsDigit(value[indexOfWhiteSpace + 1]))
            {
                throw new ArgumentException("Author not valid!");
            }
        }

        public override string ToString()
        {
            var resultBuilder = new StringBuilder();
            resultBuilder.AppendLine($"Type: {this.GetType().Name}")
                .AppendLine($"Title: {this.Title}")
                .AppendLine($"Author: {this.Author}")
                .AppendLine($"Price: {this.Price:f2}");

            string result = resultBuilder.ToString().TrimEnd();
            return result;
        }
    }
}
