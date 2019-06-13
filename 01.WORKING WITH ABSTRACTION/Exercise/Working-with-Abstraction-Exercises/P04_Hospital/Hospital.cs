namespace P04_Hospital
{
    using System.Collections.Generic;

    public class Hospital
    {
        private Dictionary<string, Department> departments;

        public Hospital()
        {
            departments = new Dictionary<string, Department>();
        }

        public void AddDepartment(string departmentName)
        {
            if (!departments.ContainsKey(departmentName))
            {
                departments[departmentName] = new Department(departmentName);
            }
        }

        public Department GetDepartment(string departmentName)
        {
            return departments[departmentName];
        }
    }
}
