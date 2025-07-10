using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using _4._WebApi_Handson;

namespace _5._WebApi_Handson.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin,POC")]
    public class EmployeeController : ControllerBase
    {
        private static List<Employee> _employees = new List<Employee>
        {
            new Employee
            {
                Id = 1,
                Name = "John",
                Salary = 50000,
                Permanent = true,
                Department = new Department { Id = 1, Name = "HR" },
                Skills = new List<Skill> { new Skill { Id = 1, Name = "C#" } },
                DateOfBirth = new DateTime(1985, 1, 15)
            }
        };

        [HttpGet]
        public ActionResult<List<Employee>> Get()
        {
            return Ok(_employees);
        }

        [HttpPut("{id}")]
        public ActionResult<Employee> Put(int id, [FromBody] Employee updatedEmp)
        {
            if (id <= 0)
                return BadRequest("Invalid employee id");

            var existing = _employees.FirstOrDefault(e => e.Id == id);
            if (existing == null)
                return BadRequest("Invalid employee id");

            existing.Name = updatedEmp.Name;
            existing.Salary = updatedEmp.Salary;
            existing.Permanent = updatedEmp.Permanent;
            existing.Department = updatedEmp.Department;
            existing.Skills = updatedEmp.Skills;
            existing.DateOfBirth = updatedEmp.DateOfBirth;

            return Ok(existing);
        }
    }
}
