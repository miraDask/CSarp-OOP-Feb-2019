namespace P04_Hospital
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            var doctors = new List<Doctor>();
            var hospital = new Hospital();

            var command = Console.ReadLine();

            while (command != "Output")
            {
                string[] commandParts = command.Split();
                var departmentName = commandParts[0];
                var doctorName = commandParts[1] + " " + commandParts[2];
                var patientName = commandParts[3];

                if (!doctors.Any(x => x.Name == doctorName))
                {
                    doctors.Add(new Doctor(doctorName));
                }

                var currentDoctor = doctors.Find(x => x.Name == doctorName);
                currentDoctor.Patients.Add(patientName);
                

                hospital.AddDepartment(departmentName);
                var currentDepartment = hospital.GetDepartment(departmentName);

                currentDepartment.AddPatient(patientName);

                command = Console.ReadLine();
            }

            command = Console.ReadLine();

            while (command != "End")
            {
                string[] commandParts = command.Split();

                if (commandParts.Length == 1)
                {
                    var departmentName = commandParts[0];
                    var currentDepartment = hospital.GetDepartment(departmentName);

                    Console.WriteLine(currentDepartment);
                }
                else if (commandParts.Length == 2 && int.TryParse(commandParts[1], out int room))
                {
                    var departmentName = commandParts[0];
                    var currentDepartment = hospital.GetDepartment(departmentName);
                    var currentRoom = currentDepartment.Rooms[room - 1];
                    currentRoom.OrderByName();
                    Console.WriteLine(currentRoom);
                }
                else
                {
                    var doctorName = commandParts[0] + " " + commandParts[1];
                    var doctor = doctors.Find(x => x.Name == doctorName);
                    Console.WriteLine(doctor);
                }
                command = Console.ReadLine();
            }
        }
    }
}
