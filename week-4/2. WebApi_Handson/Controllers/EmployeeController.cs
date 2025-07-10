using Microsoft.AspNetCore.Mvc;

namespace WebApi_Handson.Controllers
{
    [Route("api/emp")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly EmployeeService _service;

        public EmployeeController(EmployeeService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_service.GetAllEmployees());
        }

        [HttpGet("{id}", Name = "GetEmployeeById")]
        public IActionResult GetById(int id)
        {
            var emp = _service.GetById(id);
            return emp == null ? NotFound("Employee not found") : Ok(emp);
        }

        [HttpPost]
        public IActionResult Add([FromBody] Employee employee)
        {
            _service.Add(employee);
            return CreatedAtRoute("GetEmployeeById", new { id = employee.Id }, employee);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Employee employee)
        {
            var updated = _service.Update(id, employee);
            return updated ? Ok("Updated") : NotFound("Employee not found");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var deleted = _service.Delete(id);
            return deleted ? Ok("Deleted") : NotFound("Employee not found");
        }
    }
}
