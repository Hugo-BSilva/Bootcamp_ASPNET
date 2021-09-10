using CursoMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CursoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriasController : ControllerBase
    {
        private readonly Contexto _contexto;

        public CategoriasController(Contexto contexto)
        {
            _contexto = contexto;
        }
        // GET: api/<CategoriasController>
        // Chama todos os métodos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Categoria>>> GetCategorias()
        {
            return await _contexto.Categorias.ToListAsync();
        }

        // GET api/<CategoriasController>/5
        [HttpGet(template:"{id}")]
        public async Task<ActionResult<Categoria>> GetCategoria(int id)
        {
            var categoria = await _contexto.Categorias.FindAsync(id);

            if (categoria == null)
            {
                return NotFound();
            }
            return categoria;
        }

        // PUT api/<CategoriasController>/5
        [HttpPut(template: "{id}")]
        public async Task<IActionResult>PutCategoria(int id, Categoria categoria)
        {
            if (id != categoria.Id)
            {
                return BadRequest();
            }
            _contexto.Entry(categoria).State = EntityState.Modified;

            try
            {
                await _contexto.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CategoriaExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return NoContent();
        }     

        // POST api/<CategoriasController>
        [HttpPost]
        public async Task<ActionResult<Categoria>>PostCategoria(Categoria categoria)
        {
            _contexto.Categorias.Add(categoria);
            await _contexto.SaveChangesAsync();

            return CreatedAtAction("GetCategoria", routeValues: new { id = categoria.Id }, value: categoria);
        }        

        // DELETE api/<CategoriasController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Categoria>> DeleteCategoria(int id)
        {
            var categoria = await _contexto.Categorias.FindAsync(id);
            if (categoria == null)
            {
                return NotFound();
            }

            _contexto.Categorias.Remove(categoria);
            await _contexto.SaveChangesAsync();

            return categoria;
        }
        private bool CategoriaExists(int id)
        {
            return _contexto.Categorias.Any(e => e.Id == id);
        }
    }
}
