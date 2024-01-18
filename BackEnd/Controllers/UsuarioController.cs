using BackEnd.Context;
using BackEnd.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly AppDbContext _context;
        private object usuario;

        public UsuarioController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Usuario>> Get()
        {
            var usuarios = _context.Usuarios.ToList();
            if(usuarios is null)
            {
                return NotFound();
            }
            return usuarios;
        }

        [HttpGet("{id:int}", Name="ObterUsuario")]
        public ActionResult<Usuario> Get(int id)
        {
            var usuarios = _context.Usuarios.FirstOrDefault(u => u.Id == id);
            if(usuarios is null)
            {
                return NotFound();
            }
            return usuarios;
        }

        [HttpPost]

        public ActionResult Post(Usuario usuario)
        {
            _context.Usuarios.Add(usuario);
            _context.SaveChanges();

            return new CreatedAtRouteResult("ObterUsuario",
                new { id = usuario.Id }, usuario);
        }

        [HttpPut("{id:int}")]

        public ActionResult Put(int id, Usuario usuario) 
        {
            if(id != usuario.Id)
            {
                return NotFound();
            }

            _context.Entry(usuario).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();

            return Ok(usuario);        
        }

        [HttpDelete("{id:int}")]
        public ActionResult Delete(int id) 
        {
            var usuario = _context.Usuarios.FirstOrDefault(u => u.Id == id);

            if (usuario is null)
            {
                return BadRequest("Usuario não localizado...");
            }
            _context.Usuarios.Remove(usuario);
            _context.SaveChanges();

            return Ok(usuario);
        }
    }
}
