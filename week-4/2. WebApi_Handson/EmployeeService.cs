using System.Collections.Generic;
using System.Linq;

namespace WebApi_Handson
{
    public class EmployeeService
    {
        private static List<Employee> employees = new List<Employee>
        {
            new Employee { Id = 1, Name = "Alice", Department = "HR", Salary = 50000 },
            new Employee { Id = 2, Name = "Bob", Department = "IT", Salary = 60000 },
            new Employee { Id = 3, Name = "Charlie", Department = "Finance", Salary = 55000 }
        };

        public List<Employee> GetAllEmployees() => employees;

        public Employee GetById(int id) => employees.FirstOrDefault(e => e.Id == id);

        public void Add(Employee employee)
        {
            employee.Id = employees.Max(e => e.Id) + 1;
            employees.Add(employee);
        }

        public bool Update(int id, Employee updated)
        {
            var emp = employees.FirstOrDefault(e => e.Id == id);
            if (emp == null) return false;

            emp.Name = updated.Name;
            emp.Department = updated.Department;
            emp.Salary = updated.Salary;
            return true;
        }

        public bool Delete(int id)
        {
            var emp = employees.FirstOrDefault(e => e.Id == id);
            if (emp == null) return false;

            employees.Remove(emp);
            return true;
        }
    }
}
