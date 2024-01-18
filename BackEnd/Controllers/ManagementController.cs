using BackEnd.Context;
using BackEnd.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ManagementController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ManagementController(AppDbContext context)
        {
            _context = context;
        }
        [HttpGet]

        public ActionResult<IEnumerable<Management>> Get() 
        {
            return _context.Managements.ToList();
        
        }

        [HttpGet("{id:int}", Name = "ObterManagement")]
        public ActionResult<Management> Get(int id)
        {
            var managements = _context.Managements.FirstOrDefault(m => m.Id == id);
            if (managements is null)
            {
                return NotFound();
            }
            return managements;
        }

        [HttpPost]

        public ActionResult Post(Management management)
        {
            _context.Managements.Add(management);
            _context.SaveChanges();

            return new CreatedAtRouteResult("ObterUsuario",
                new { id = management.Id }, management);
        }

        [HttpPut("{id:int}")]

        public ActionResult Put(int id, Management management)
        {
            if (id != management.Id)
            {
                return NotFound();
            }

            _context.Entry(management).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();

            return Ok(management);
        }

        [HttpDelete("{id:int}")]
        public ActionResult Delete(int id)
        {
            var management = _context.Managements.FirstOrDefault(m => m.Id == id);

            if (management is null)
            {
                return BadRequest("Registro não localizado...");
            }
            _context.Managements.Remove(management);
            _context.SaveChanges();

            return Ok(management);
        }
    }
}
