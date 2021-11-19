#region Imports
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Prueba_HPTP.DTO;
using Prueba_HPTP.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
#endregion

namespace Prueba_HPTP.Controllers
{

    [Produces("application/json")]
    [Route("api/Employees")]
    public class EmployeeController : Controller
    {

        private readonly PruebaContext _context;

        public EmployeeController(PruebaContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<EmployeDTO> GetEmployee()
        {
            return Mapper.Map<IEnumerable<EmployeDTO>>(_context.Employe.OrderByDescending(x => x.Id));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetEmployee([FromRoute] int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var employee = await _context.Employe.SingleOrDefaultAsync(m => m.Id == id);

            if (employee == null)
                return NotFound();
            return Ok(Mapper.Map<EmployeDTO>(employee));
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] EmployeDTO employee)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var e = Mapper.Map<Employe>(employee);
            _context.Employe.Add(e);
            await _context.SaveChangesAsync();
            employee.Id = e.Id;
            return CreatedAtAction("GetEmployee", employee);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] EmployeDTO employee)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (id != employee.Id)
                return BadRequest();

            _context.Entry(Mapper.Map<Employe>(employee)).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Employe.Any(e => e.Id == id))
                    return NotFound();
                else
                    throw;
            }
            return CreatedAtAction("GetEmployee", employee);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var employee = await _context.Employe.SingleOrDefaultAsync(m => m.Id == id);
            if (employee == null)
                return NotFound();

            _context.Employe.Remove(employee);
            await _context.SaveChangesAsync();
            return Ok(Mapper.Map<EmployeDTO>(employee));
        }
    }
}