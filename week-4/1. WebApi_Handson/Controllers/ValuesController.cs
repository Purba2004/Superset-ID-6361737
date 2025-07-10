using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace FirstWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private static List<string> data = new List<string> { "value1", "value2" };

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(data);
        }

        [HttpPost]
        public IActionResult Post([FromBody] string value)
        {
            data.Add(value);
            return Ok(data);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] string value)
        {
            if (id < 0 || id >= data.Count)
                return BadRequest("Invalid ID");

            data[id] = value;
            return Ok(data);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (id < 0 || id >= data.Count)
                return BadRequest("Invalid ID");

            data.RemoveAt(id);
            return Ok(data);
        }
    }
}
