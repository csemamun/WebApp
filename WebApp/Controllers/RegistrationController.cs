using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApp.Models;
using WebApp.Services;

namespace WebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegistrationController : ControllerBase
    {
        private readonly IRegistration _reg;

        public RegistrationController(IRegistration reg)
        {
            _reg = reg;
        }
        [HttpGet]
        public async Task<IEnumerable<Registration>> Get()
        {
            return await _reg.GetAll();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Registration>> GetById(int id)
        {
            return await _reg.GetById(id);
        }
        [HttpPost]
        public async Task<ActionResult<Registration>> Create(Registration reg)
        {
            await _reg.Create(reg);
            return CreatedAtAction(nameof(GetById), new { reg.Id }, reg);
        }

        [HttpPut]
        public async Task<ActionResult> Update(int id, Registration reg)
        {
            if (id != reg.Id)
            {
                return BadRequest();
            }
            await _reg.Update(reg);
            return NoContent();

        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var reg = await _reg.GetById(id);
            if (reg == null)
            {
                return NotFound();
            }
            await _reg.Delete(reg.Id);
            return NoContent();
        }

    }
}
