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
    public class EditorialController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public EditorialController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/<EditorialController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var listEditorial = await _context.Editorial.ToListAsync();
                return Ok(listEditorial);
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
                var editorial = await _context.Editorial.FindAsync(id);

                if (editorial == null)
                {
                    return NotFound();
                }

                return Ok(editorial);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }




        // POST api/<EditorialController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Editoriales editorial)
        {
            try
            {
                _context.Add(editorial);
                await _context.SaveChangesAsync();

                return Ok(editorial);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        // PUT api/<EditorialController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Editoriales editorial)
        {
            try
            {
                if (id != editorial.Id)
                {
                    return BadRequest();
                }

                _context.Update(editorial);
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
                var editorial = await _context.Editorial.FindAsync(id);

                if (editorial == null)
                {
                    return BadRequest();
                }

                _context.Remove(editorial);
                await _context.SaveChangesAsync();
                return Ok(new { message = "Eliminado el id " + editorial.Id + " satisfactoriamente" });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);

                throw;
            }
        }
    }
}
