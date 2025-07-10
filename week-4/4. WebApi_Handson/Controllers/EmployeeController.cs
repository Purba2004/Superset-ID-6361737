using Microsoft.AspNetCore.Mvc;

namespace _4._WebApi_Handson.Controllers
{
    [Route("api/emp5")] // make it unique

    [ApiController]
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
            return Ok(EmployeeData.Employees); // reuse the data
        }



        [HttpPut("{id}")]
        public ActionResult<Employee> Put(int id, [FromBody] Employee updatedEmp)
        {
            if (id <= 0)
                return BadRequest("Invalid employee id");

            var existingEmp = _employees.FirstOrDefault(e => e.Id == id);

            if (existingEmp == null)
                return BadRequest("Invalid employee id");

            existingEmp.Name = updatedEmp.Name;
            existingEmp.Salary = updatedEmp.Salary;
            existingEmp.Permanent = updatedEmp.Permanent;
            existingEmp.Department = updatedEmp.Department;
            existingEmp.Skills = updatedEmp.Skills;
            existingEmp.DateOfBirth = updatedEmp.DateOfBirth;

            return Ok(existingEmp);
        }
    }
}
