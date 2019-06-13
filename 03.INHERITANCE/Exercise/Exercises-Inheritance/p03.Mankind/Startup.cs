namespace p03.Mankind
{
    using System;

    public class Startup
    {
        public static void Main()
        {
            string[] studentData = Console.ReadLine().Split(' ',StringSplitOptions.RemoveEmptyEntries);
            string[] workerData = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            string studentFirstName = studentData[0];
            string studentLastName = studentData[1];
            string facultyNumber = studentData[2];

            string workerFirstName = workerData[0];
            string workerLastName = workerData[1];
            decimal weekSalary = decimal.Parse(workerData[2]);
            decimal workingHoursPerDay = decimal.Parse(workerData[3]);

            try
            {
                var student = new Student(studentFirstName, studentLastName, facultyNumber);
                var worker = new Worker(workerFirstName, workerLastName, weekSalary, workingHoursPerDay);
                Console.WriteLine(student);
                Console.WriteLine();
                Console.WriteLine(worker);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
