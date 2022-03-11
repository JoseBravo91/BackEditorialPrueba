using BackEditorialPrueba.Models;
using BackEditorialPrueba.Models.ModelStructure;
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
    public class AutorController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public AutorController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/<EditorialController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var listAutor = await _context.Autor.ToListAsync();
                var respuesta = new List<AutoresDto>();

                foreach (var item in listAutor)
                {
                    respuesta.Add(new AutoresDto
                    {
                        Id = item.Id,
                        CiudadProcedencia = item.CiudadProcedencia,
                        CorreoElectronico = item.CorreoElectronico,
                        NombreAutor = item.NombreAutor,
                        FechaNacimiento = item.FechaNacimiento,
                        IdEditorial = item.IdEditorial,
                        NombreEditorial = _context.Editorial.Where(x => x.Id == item.IdEditorial).FirstOrDefault().NombreEditorial
                });
                }
                return Ok(respuesta);
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
                var Autor = await _context.Autor.FindAsync(id);

                if (Autor == null)
                {
                    return NotFound();
                }

                return Ok(Autor);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        // POST api/<EditorialController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Autores autor)
        {
            try
            {
                _context.Add(autor);
                await _context.SaveChangesAsync();

                return Ok(autor);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        // PUT api/<EditorialController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Autores autor)
        {
            try
            {
                if (id != autor.Id)
                {
                    return BadRequest();
                }

                _context.Update(autor);
                await _context.SaveChangesAsync();
                return Ok(new { message = "Autor actualizado con exito" });


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
                var autor = await _context.Autor.FindAsync(id);

                if (autor == null)
                {
                    return BadRequest();
                }

                _context.Remove(autor);
                await _context.SaveChangesAsync();
                return Ok(new { message = "Eliminado el id " + autor.Id + " satisfactoriamente" });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);

                throw;
            }
        }
    }
}
