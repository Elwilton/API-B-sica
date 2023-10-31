using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppPraticar.Entitys;
using AppPraticar.Persistence;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AppPraticar.Controllers
{
    [Route("api/DevEvents")]
    [ApiController]
    public class DevEventsController : ControllerBase
    {
        private readonly DevEventsDbContext _context;

        public DevEventsController(DevEventsDbContext context)
        {
            _context = context ;
        }

        // GET: api/values
        [HttpGet]
        public IActionResult GetAll()
        {
            var devEvents = _context.DevEvents.Where(d => !d.IsDeleted).ToList();
            return Ok(devEvents);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            var devEvents = _context.DevEvents.SingleOrDefault(d => d.ID == id);

            if(devEvents== null)
            {
                return NotFound();
            }

            return Ok(devEvents);
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post(DevEvent devEvents)
        {
            _context.DevEvents.Add(devEvents);
            return CreatedAtAction(nameof(GetById), new {id= devEvents.ID}, devEvents);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public IActionResult Update(Guid id, DevEvent input)
        {
            var devEvents = _context.DevEvents.SingleOrDefault(d => d.ID == id);

            if (devEvents == null)
            {
                return NotFound();
            }

            devEvents.Update(input.Title, input.Description, input.StartDate, input.EndDate);

            return NoContent();
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            var devEvents = _context.DevEvents.SingleOrDefault(d => d.ID == id);

            if (devEvents == null)
            {
                return NotFound();
            }
            devEvents.Delete();

            return NoContent();
        }
    }
}

