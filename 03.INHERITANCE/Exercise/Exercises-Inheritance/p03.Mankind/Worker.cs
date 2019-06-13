namespace p03.Mankind
{
    using System;
    using System.Text;

    public class Worker : Human
    {
        private const string exeptionText = "Expected value mismatch! Argument: {0}";

        private decimal weekSalary;
        private decimal workHoursPerDay;

        public Worker(string firstName, string lastName, decimal weekSalary, decimal workingHoursPerDay)
            : base(firstName, lastName)
        {
            this.WeekSalary = weekSalary;
            this.WorkingHoursPerDay = workingHoursPerDay;
        }

        public decimal WeekSalary
        {
            get => this.weekSalary;
            set
            {
                if (value <= 10)
                {
                    throw new ArgumentException(string.Format(exeptionText, nameof(this.weekSalary)));
                }

                this.weekSalary = value;
            }
        }

        public decimal WorkingHoursPerDay
        {
            get => this.workHoursPerDay;
            set
            {
                if (value < 1 || value > 12)
                {
                    throw new ArgumentException(string.Format(exeptionText, nameof(this.workHoursPerDay)));
                }

                this.workHoursPerDay = value;
            }
        }

        public decimal GetSalaryPerHour()
        {
            decimal salaryPerHour = this.weekSalary / (this.WorkingHoursPerDay * 5);
            return salaryPerHour;
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
           

            result.AppendLine(base.ToString());
            result.AppendLine($"Week Salary: {this.WeekSalary:f2}");
            result.AppendLine($"Hours per day: {this.workHoursPerDay:f2}");
            result.AppendLine($"Salary per hour: {GetSalaryPerHour():f2}");

            return result.ToString().TrimEnd();
        }
    }
}
