using BackEditorialPrueba.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BackEditorialPrueba.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LibrosController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public LibrosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/<EditorialController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var listLibros = await _context.Libro.ToListAsync();
                return Ok(listLibros);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        // GET api/<EditorialController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var libro = await _context.Libro.FindAsync(id);

                if (libro == null)
                {
                    return NotFound();
                }

                return Ok(libro);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        // POST api/<EditorialController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Libros libro)
        {
            try
            {
                var maxReg = _context.Editorial.Where(x => x.Id == libro.IdEditorial).FirstOrDefault().MaximoLibrosRegistrados;
                var countlistLibros = _context.Libro.Where(x => x.IdEditorial == libro.IdEditorial).ToList();
                var lenghLibros = countlistLibros.Count();

                if (lenghLibros >= maxReg) 
                {
                    libro = null;
                    return Ok(libro);
                    
                }
                else{

                    _context.Add(libro);
                    await _context.SaveChangesAsync();

                    return Ok(libro);
                }

             
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        // PUT api/<EditorialController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Libros libro)
        {
            try
            {
                if (id != libro.Id)
                {
                    return BadRequest();
                }

                _context.Update(libro);
                await _context.SaveChangesAsync();
                return Ok(new { message = "Editorial actualizado con exito" });


            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }


        // DELETE api/<EditorialController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var libro = await _context.Libro.FindAsync(id);

                if (libro == null)
                {
                    return BadRequest();
                }

                _context.Remove(libro);
                await _context.SaveChangesAsync();
                return Ok(new { message = "Eliminado el id " + libro.Id + " satisfactoriamente" });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);

                throw;
            }
        }
    }
}
