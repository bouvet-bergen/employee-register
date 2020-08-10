using System;
using System.Collections.Generic;

namespace EmployeeRegister.Core.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Department { get; set; }
        public DateTime Birth { get; set; }
        public int Age => CalculateAge();

        public int? ManagerId { get; set; }
        public Employee Manager { get; set; }

        public List<Employee> Employees { get; set; }

        private int CalculateAge()
        {
            var now = DateTime.Now;

            if (now.Month > Birth.Month || (now.Month == Birth.Month && now.Day < Birth.Day))
                return now.Year - Birth.Year;

            return (now.Year - Birth.Year) - 1;
        }
    }
}
