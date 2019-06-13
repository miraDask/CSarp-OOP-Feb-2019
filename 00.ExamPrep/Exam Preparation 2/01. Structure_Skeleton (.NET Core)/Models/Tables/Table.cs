using SoftUniRestaurant.Models.Drinks.Contracts;
using SoftUniRestaurant.Models.Foods.Contracts;
using SoftUniRestaurant.Models.Tables.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftUniRestaurant.Models.Tables
{
    public abstract class Table : ITable
    {
        private int capacity;
        private int numberOfPeople;
        private List<IFood> foods;
        private List<IDrink> drinks;

        protected Table(int tableNumber, int capacity, decimal pricePerPerson)
        {
            this.TableNumber = tableNumber;
            this.Capacity = capacity;
            this.PricePerPerson = pricePerPerson;
            this.IsReserved = false;
            this.foods = new List<IFood>();
            this.drinks = new List<IDrink>();
            this.numberOfPeople = 0;
        }

        public int TableNumber { get; }

        public int NumberOfPeople
        {
            get => this.numberOfPeople;
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Cannot place zero or less people!");
                }

                this.numberOfPeople = value;
            }
        }

        public int Capacity
        {
            get => this.capacity;
            private set
            {
                
                if (value <= 0)
                {
                    throw new ArgumentException("Capacity has to be greater than 0");
                }

               this.capacity = value;
            }
        }

        public decimal PricePerPerson { get; private set; }

        public bool IsReserved { get; private set; }

        public decimal Price =>  this.numberOfPeople * PricePerPerson;

        public void Clear()
        {
            this.drinks.Clear();
            this.foods.Clear();
            this.IsReserved = false;
            this.numberOfPeople = 0;
        }

        public decimal GetBill()
        {
            return this.foods.Sum(x => x.Price)
                + this.drinks.Sum(x => x.Price)
                + this.Price;
        }

        public void OrderDrink(IDrink drink)
        {
            this.drinks.Add(drink);
        }

        public void OrderFood(IFood food)
        {
            this.foods.Add(food);
        }

        public void Reserve(int numberOfPeople)
        {
            this.IsReserved = true;
            this.NumberOfPeople = numberOfPeople;
        }

        public string GetFreeTableInfo()
        {
            StringBuilder result = new StringBuilder();

            result.AppendLine($"Table: {this.TableNumber}")
                 .AppendLine($"Type: {this.GetType().Name}")
                 .AppendLine($"Capacity: {this.Capacity}")
                 .AppendLine($"Price per Person: {this.PricePerPerson}");

            return result.ToString().TrimEnd();
        }

        public string GetOccupiedTableInfo()
        {
            StringBuilder result = new StringBuilder();

            result.AppendLine($"Table: {this.TableNumber}")
                 .AppendLine($"Type: {this.GetType().Name}")
                 .AppendLine($"Number of people: {this.NumberOfPeople}");

            string foodOrders = this.foods.Count == 0 ? "None" : this.foods.Count.ToString();

            result.AppendLine($"Food orders: {foodOrders}");

            foreach (var food in this.foods)
            {
                result.AppendLine(food.ToString());
            }

            string drinksOrders = this.drinks.Count == 0 ? "None" : this.drinks.Count.ToString();

            result.AppendLine($"Drink orders: {drinksOrders}");

            foreach (var drink in this.drinks)
            {
                result.AppendLine(drink.ToString());
            }

            return result.ToString().TrimEnd();
        }
    }
}
